using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http.Authentication;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.Youku
{
    /// <summary>
    ///  优酷开放平台授权核心处理类
    /// </summary>
    public class YoukuHandler : OAuthHandler<YoukuOptions>
    {
        public YoukuHandler(HttpClient backchannel) : base(backchannel) { }

        /// <summary>
        ///  回调后验证通信
        /// </summary>
        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            var query = new FormUrlEncodedContent(new Dictionary<string,string>
            {
                {"client_id",  Options.ClientId},
                {"access_token", tokens.AccessToken}
            });
            var response = await Backchannel.PostAsync(Options.UserInformationEndpoint, query, Context.RequestAborted);
            response.EnsureSuccessStatusCode();
            var payload = JObject.Parse(await response.Content.ReadAsStringAsync());

            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), properties, Options.AuthenticationScheme);
            var context = new OAuthCreatingTicketContext(ticket, Context, Options, Backchannel, tokens, payload);


            var identifier = YoukuHelper.GetId(payload);
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:youku:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var name = YoukuHelper.GetName(payload);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:youku:name", name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var avatar = YoukuHelper.GetAvatar(payload);
            if (!string.IsNullOrEmpty(avatar))
            {
                identity.AddClaim(new Claim("urn:youku:avatar", avatar, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            await Options.Events.CreatingTicket(context);

            return context.Ticket;
        }
    }
}