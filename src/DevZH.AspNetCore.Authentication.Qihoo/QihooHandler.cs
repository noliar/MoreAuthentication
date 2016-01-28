using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using DevZH.AspNetCore.Authentication.Internal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNetCore.Authentication.Qihoo
{
    /// <summary>
    /// 对一系列认证过程的调控
    /// </summary>
    public class QihooHandler : OAuthHandler<QihooOptions>
    {
        public QihooHandler(HttpClient backchannel) : base(backchannel)
        {
        }

        /// <summary>
        /// 主要生成的是 Authorization 的链接。
        /// </summary>
        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            var queryBuilder = new QueryBuilder {
                { "client_id", Options.ClientId },
                { "scope", FormatScope() },
                { "response_type", "code" },
                { "redirect_uri", redirectUri },
                { "state", Options.StateDataFormat.Protect(properties) },
                { "display", Options.Display.GetDescription() },
                { "relogin", Options.ReLogin }
            };
            return Options.AuthorizationEndpoint + queryBuilder;
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

            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), properties, Options.AuthenticationScheme);
            var context = new OAuthCreatingTicketContext(ticket, Context, Options, Backchannel, tokens, payload);

            var identifier = QihooHelper.GetId(payload);
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:qihoo:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var name = QihooHelper.GetName(payload);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:qihoo:name", name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var avatar = QihooHelper.GetAvatar(payload);
            if (!string.IsNullOrEmpty(avatar))
            {
                identity.AddClaim(new Claim("urn:qihoo:avatar", avatar, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            await Options.Events.CreatingTicket(context);

            return context.Ticket;
        }
    }
}
