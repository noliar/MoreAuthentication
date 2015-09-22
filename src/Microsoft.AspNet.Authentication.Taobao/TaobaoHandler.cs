using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Authentication.Internal;

namespace Microsoft.AspNet.Authentication.Taobao
{
    /// <summary>
    ///  淘宝授权核心处理类
    /// </summary>
    public class TaobaoHandler : OAuthHandler<TaobaoOptions>
    {
        public TaobaoHandler(HttpClient backchannel) : base(backchannel) { }

        /// <summary>
        ///  构建授权链接
        /// </summary>
        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            return base.BuildChallengeUrl(properties, redirectUri) + $"&view={Options.View.GetDescription()}";
        }

        /// <summary>
        ///  回调后本机沟通
        /// </summary>
        protected override Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            var identifier = tokens.Response.Value<string>("taobao_user_id");
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:taobao:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }
            var name = System.Uri.UnescapeDataString(tokens.Response.Value<string>("taobao_user_nick"));
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:taobao:name", name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }
            return base.CreateTicketAsync(identity, properties, tokens);
        }
    }
}