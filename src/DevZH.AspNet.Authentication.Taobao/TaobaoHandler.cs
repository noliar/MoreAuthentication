using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using DevZH.AspNetCore.Authentication.Internal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http.Authentication;

namespace DevZH.AspNetCore.Authentication.Taobao
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
            var identifier = TaobaoHelper.GetId(tokens.Response);
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:taobao:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }
            var name = TaobaoHelper.GetName(tokens.Response);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:taobao:name", name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }
            return base.CreateTicketAsync(identity, properties, tokens);
        }
    }
}