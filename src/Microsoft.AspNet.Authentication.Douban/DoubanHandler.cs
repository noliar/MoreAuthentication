using Microsoft.AspNet.Authentication.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Http.Authentication;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNet.Authentication.Douban
{
    /// <summary>
    ///  豆瓣开放平台授权核心处理类
    /// </summary>
    public class DoubanHandler : OAuthHandler<DoubanOptions>
    {
        public DoubanHandler(HttpClient backchannel) : base(backchannel) { }

        /// <summary>
        ///  格式化权限列表。默认实现是以空格为分割，豆瓣以逗号分割
        /// </summary>
        protected override string FormatScope()
        {
            return string.Join(",", Options.Scope);
        }

        /// <summary>
        ///  与本站通信同步
        /// </summary>
        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, Options.UserInformationEndpoint);
            message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokens.AccessToken);
            var response = await Backchannel.SendAsync(message, Context.RequestAborted);
            response.EnsureSuccessStatusCode();
            var payload = JObject.Parse(await response.Content.ReadAsStringAsync());

            var notification = new OAuthAuthenticatedContext(Context, Options, Backchannel, tokens, payload)
            {
                Properties = properties,
                Principal = new ClaimsPrincipal(identity)
            };

            var identifier = DoubanHelper.GetId(payload);
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:douban:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var name = DoubanHelper.GetName(payload);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:douban:name", name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var avatar = DoubanHelper.GetAvatar(payload);
            if (!string.IsNullOrEmpty(avatar))
            {
                identity.AddClaim(new Claim("urn:douban:avatar", avatar, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var uid = DoubanHelper.GetUid(payload);
            if (!string.IsNullOrEmpty(uid))
            {
                identity.AddClaim(new Claim("urn:douban:uid", uid, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            await Options.Events.Authenticated(notification);

            return new AuthenticationTicket(notification.Principal, notification.Properties, notification.Options.AuthenticationScheme);
        }
    }
}
