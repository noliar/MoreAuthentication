using Microsoft.AspNet.Authentication.OAuth;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Http.Authentication;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNet.Authentication.Yixin
{
    /// <summary>
    ///  易信开放平台授权核心处理类
    /// </summary>
    public class YixinAuthenticationHandler : OAuthAuthenticationHandler<YixinAuthenticationOptions>
    {
        public YixinAuthenticationHandler(HttpClient backchannel) : base(backchannel) { }

        /// <summary>
        ///  构建授权链接
        /// </summary>
        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            if (!Options.CallbackPath.HasValue) redirectUri = "http://open.yixin.im/resource/oauth2_callback.html";
            return base.BuildChallengeUrl(properties, redirectUri);
        }

        /// <summary>
        ///  获取相关授权 Token
        /// </summary>
        protected override Task<OAuthTokenResponse> ExchangeCodeAsync(string code, string redirectUri)
        {
            if (!Options.CallbackPath.HasValue) redirectUri = "http://open.yixin.im/resource/oauth2_callback.html";
            return base.ExchangeCodeAsync(code, redirectUri);
        }

        /// <summary>
        ///  与本站通信同步
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

            var identifier = YixinAuthenticationHelper.GetId(payload);
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:yixin:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var name = YixinAuthenticationHelper.GetName(payload);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:yixin:name", name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var icon = YixinAuthenticationHelper.GetIcon(payload);
            if (!string.IsNullOrEmpty(icon))
            {
                identity.AddClaim(new Claim("urn:yixin:icon", icon, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            await Options.Notifications.Authenticated(notification);

            return new AuthenticationTicket(notification.Principal, notification.Properties, notification.Options.AuthenticationScheme);
        }
    }
}
