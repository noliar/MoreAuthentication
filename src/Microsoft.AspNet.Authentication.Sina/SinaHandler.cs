using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication.Internal;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http.Authentication;

namespace Microsoft.AspNet.Authentication.Sina
{
    /// <summary>
    ///  新浪授权核心处理类
    /// </summary>
    public class SinaHandler : OAuth.OAuthHandler<SinaOptions>
    {
        public SinaHandler(HttpClient backchannel) : base(backchannel) { }

        /// <summary>
        /// 格式化应用权限
        /// </summary>
        protected override string FormatScope()
        {
            return string.Join(",", Options.Scope);
        }

        /// <summary>
        ///  构建授权链接
        /// </summary>
        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            var append = $"&display={Options.Display.GetDescription()}";
            if (Options.IsForce) append += "&forcelogin=true";
            if (Options.Language == SinaOptions.LanguageType.English) append += "&language=en";
            return base.BuildChallengeUrl(properties, redirectUri) + append;
        }

        /// <summary>
        ///  根据 token，与本站配对通信
        /// </summary>
        protected override Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            var identifier = tokens.Response.Value<string>("uid");
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:sina:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }
            return base.CreateTicketAsync(identity, properties, tokens);
        }
    }
}