using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using DevZH.AspNet.Authentication.Internal;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Http.Extensions;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.Baidu
{
    /// <summary>
    /// 对一系列认证过程的调控
    /// </summary>
    public class BaiduHandler : OAuthHandler<BaiduOptions>
    {
        public BaiduHandler(HttpClient backchannel) : base(backchannel)
        {
        }

        /// <summary>
        /// 主要生成的是 Authorization 的链接。其中，display 等是百度对 OAuth 2.0 的非标准扩展标识，用来控制外观及行为显示
        /// </summary>
        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            var queryBuilder = new QueryBuilder {
                { "client_id", this.Options.ClientId },
                { "scope", this.FormatScope() },
                { "response_type", "code" },
                { "redirect_uri", redirectUri },
                { "state", Options.StateDataFormat.Protect(properties) },
                { "display", Options.Display.GetDescription()}
            };
            if (Options.IsForce) queryBuilder.Add("force_login", "1");
            if (Options.IsConfirm) queryBuilder.Add("confirm_login", "1");
            if (Options.UseSms) queryBuilder.Add("login_type", "sms");
            return Options.AuthorizationEndpoint + queryBuilder.ToString();
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

            var notification = new OAuthCreatingTicketContext(Context, Options, Backchannel, tokens, payload)
            {
                Properties = properties,
                Principal = new ClaimsPrincipal(identity)
            };

            var identifier = BaiduHelper.GetId(payload);
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:baidu:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var name = BaiduHelper.GetName(payload);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:baidu:name", name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var portrait = BaiduHelper.GetPortrait(payload);
            if (!string.IsNullOrEmpty(portrait))
            {
                identity.AddClaim(new Claim("urn:baidu:portrait", portrait, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            await Options.Events.CreatingTicket(notification);

            return new AuthenticationTicket(notification.Principal, notification.Properties, notification.Options.AuthenticationScheme);
        }
    }
}