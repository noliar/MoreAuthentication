using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using DevZH.AspNetCore.Authentication.Internal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http.Authentication;

namespace DevZH.AspNetCore.Authentication.Sina
{
    /// <summary>
    ///  新浪授权核心处理类
    /// </summary>
    public class SinaHandler : OAuthHandler<SinaOptions>
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
        /// <remarks>
        ///  因为文档上说获取账号信息的接口有频次限制，所以就没获取了
        /// </remarks>
        protected override Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            var identifier = SinaHelper.GetId(tokens.Response);
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:sina:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }
            return base.CreateTicketAsync(identity, properties, tokens);
        }
    }
}