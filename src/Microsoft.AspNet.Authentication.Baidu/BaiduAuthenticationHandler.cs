using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http.Extensions;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Http.Authentication;
using System.Security.Claims;
using Microsoft.AspNet.Http.Features.Authentication;
using Microsoft.Framework.Internal;

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
        ///  用 AuthorizationCode 获取 token 等参数
        /// </summary>
        protected override Task<OAuthTokenResponse> ExchangeCodeAsync(string code, string redirectUri)
        {
#if DEBUG
                // TODO
                System.Console.WriteLine(code);
                var cookie = this.Context.Response.Cookies;
                System.Console.WriteLine(cookie.ToString());
#endif
            redirectUri = Options.IsOob ? "oob" : redirectUri;
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

        /// <summary>
        ///  未授权时跳转到授权页面
        /// </summary>
        /// <returns></returns>
        protected override Task<bool> HandleUnauthorizedAsync([NotNull]ChallengeContext context)
        {
            var properties = new AuthenticationProperties(context.Properties);
            if (string.IsNullOrEmpty(properties.RedirectUri))
            {
                properties.RedirectUri = CurrentUri;
            }
            GenerateCorrelationId(properties);
            var redirect = string.Empty;
            if (!Options.IsOob)
            {
                redirect = BuildChallengeUrl(properties, BuildRedirectUri(Options.CallbackPath));
            }
            else
            {
                // redirect = BuildRedirectUri(Options.CallbackPath);
                redirect = BuildChallengeUrl(properties, "oob");
            }
            Options.Notifications.ApplyRedirect(new OAuthApplyRedirectContext(Context, Options, properties, redirect));
            // tip: 原本是打算新建窗口来相对友好地处理 oob。
            //if (Options.IsOob)
            //{
            //    var window = BuildChallengeUrl(properties, "oob");
            //    await Context.Response.WriteAsync($"<script>window.open('{window}')</script>");
            //}
            return Task.FromResult(true);
        }
    }
}