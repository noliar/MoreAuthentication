using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http.Extensions;
using Microsoft.AspNet.Http.Internal;
using Microsoft.AspNet.WebUtilities;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNet.Http.Authentication;
using System.Security.Claims;
using Microsoft.AspNet.Http.Features.Authentication;
using Microsoft.Framework.Internal;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;

namespace Microsoft.AspNet.Authentication.Baidu
{
    /// <summary>
    /// 对一系列认证过程的调控
    /// </summary>
    internal class BaiduAuthenticationHandler : OAuthAuthenticationHandler<BaiduAuthenticationOptions>
    {
        public BaiduAuthenticationHandler(HttpClient backchannel) : base(backchannel)
        {
        }

        /// <summary>
        /// 主要生成的是 Authorization 的链接。其中，display 是百度对 OAuth 2.0 的非标准扩展标识，用来控制外观显示
        /// </summary>
        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            var append = $"&display={Options.Display.GetDescription()}";
            if (Options.IsForce) append += "&force_login=1";
            if (Options.IsConfirm) append += "confirm_login=1";
            if (Options.UseSms) append += "&login_type=sms";
#if DEBUG
                // TODO
                redirectUri = BuildRedirectUri(redirectUri);
                Console.WriteLine(redirectUri);
#endif
            return base.BuildChallengeUrl(properties, redirectUri) + append;
        }

        // 然而，现在并没有什么乱用，还没想好怎么搞比较恰当
        [Obsolete]
        private new string BuildRedirectUri(string uri)
        {
            if(Options.IsOob)
            {
                return "oob";
            }
            return uri;
        }

        protected override Task<OAuthTokenResponse> ExchangeCodeAsync(string code, string redirectUri)
        {
            
            #if DEBUG
                // TODO
                redirectUri = BuildRedirectUri(redirectUri);
                Console.WriteLine(code);
                var cookie = this.Context.Response.Cookies;
                Console.WriteLine(cookie.ToString());
            #endif
            return base.ExchangeCodeAsync(code, redirectUri);
        }

        /// <summary>
        /// 根据获取到的 token，来得到登录用户的基本信息，并配对。
        /// </summary>
        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            var endpoint = Options.UserInformationEndpoint + "?access_token=" + UrlEncoder.UrlEncode(tokens.AccessToken);
            var response = await Backchannel.GetAsync(endpoint, Context.RequestAborted);
            response.EnsureSuccessStatusCode();
            var payload = JObject.Parse(await response.Content.ReadAsStringAsync());

            var notification = new OAuthAuthenticatedContext(Context, Options, Backchannel, tokens, payload)
            {
                Properties = properties,
                Principal = new ClaimsPrincipal(identity)
            };

            var identifier = BaiduAuthenticationHelper.GetId(payload);
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:baidu:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var name = BaiduAuthenticationHelper.GetName(payload);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:baidu:name", name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var portrait = BaiduAuthenticationHelper.GetPortrait(payload);
            if (!string.IsNullOrEmpty(portrait))
            {
                identity.AddClaim(new Claim("urn:baidu:portrait", portrait, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            await Options.Notifications.Authenticated(notification);

            return new AuthenticationTicket(notification.Principal, notification.Properties, notification.Options.AuthenticationScheme);
        }

        //public override async Task<bool> InvokeAsync()
        //{
        //    if(Options.CallbackPath.HasValue && (Options.CallbackPath == Request.Path || Options.CallbackPath == oob))
        //    {
        //        return await InvokeReturnPathAsync();
        //    }
        //    return false;
        //}
    }
}