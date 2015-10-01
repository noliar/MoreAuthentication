using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http.Authentication;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.Tencent
{
    /// <summary>
    ///  腾讯开放平台用户接入授权处理核心类
    /// </summary>
    public class TencentHandler : OAuthHandler<TencentOptions>
    {
        public TencentHandler(HttpClient backchannel) : base(backchannel) { }

        /// <summary>
        /// 格式化应用权限
        /// </summary>
        protected override string FormatScope()
        {
            return string.Join(",", Options.Scope);
        }

        /// <summary>
        ///  创建授权链接
        /// </summary>
        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            var url = base.BuildChallengeUrl(properties, redirectUri);
            if (Options.IsMobile) url += "&display=mobile";
            return url;
        }

        /// <summary>
        ///  与令牌服务器沟通，获取用户相关令牌
        /// </summary>
        /// <param name="code">授权码</param>
        /// <param name="redirectUri">回调地址</param>
        protected override async Task<OAuthTokenResponse> ExchangeCodeAsync(string code, string redirectUri)
        {
            var query = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", Options.ClientId },
                { "redirect_uri", redirectUri },
                { "client_secret", Options.ClientSecret},
                { "code", code},
                { "grant_type","authorization_code"}
            });
            var message = new HttpRequestMessage(HttpMethod.Post, Options.TokenEndpoint)
            {
                Content = query
            };
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await Backchannel.SendAsync(message, Context.RequestAborted);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            // 虽然标准是说 access_token 的范围是 0x20-0x7e，不过我看腾讯的实现看起来像 MD5 后的
            // 标准不是说返回 json 或 xml 么，，，这返回的 类似 query 的又是什么坑爹货，难道我记错了
            result = "{\"" + result.Replace("=", "\":\"").Replace("&", "\",\"") + "\"}";
            return new OAuthTokenResponse(JObject.Parse(result));
        }

        /// <summary>
        ///  与本站通信，获得可获取用户基本信息
        /// </summary>
        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            var openIdEndpoint = Options.OpenIdEndpoint + "?access_token=" + tokens.AccessToken;
            var response = await Backchannel.GetAsync(openIdEndpoint, Context.RequestAborted);
            response.EnsureSuccessStatusCode();
            // 要不要这么懒……这回用正则看看
            var tmp = await response.Content.ReadAsStringAsync();

            var regex = new System.Text.RegularExpressions.Regex("callback\\((?<json>[ -~]+)\\);");
            // just throw it when error appears.
            var json = JObject.Parse(regex.Match(tmp).Groups["json"].Value);
            var identifier = TencentHelper.GetOpenId(json);
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:qq:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "oauth_consumer_key", Options.ClientId },
                { "access_token", tokens.AccessToken },
                {"openid", identifier }
            });
            response = await Backchannel.PostAsync(Options.UserInformationEndpoint, content);
            response.EnsureSuccessStatusCode();
            var info = JObject.Parse(await response.Content.ReadAsStringAsync());
            info.Add("id", identifier);

            var notification = new OAuthCreatingTicketContext(Context, Options, Backchannel, tokens, info)
            {
                Properties = properties,
                Principal = new ClaimsPrincipal(identity)
            };

            var name = TencentHelper.GetNickName(info);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:qq:nickname", name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }
            var figure = TencentHelper.GetFigure(info);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim("urn:qq:figure", figure, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            await Options.Events.CreatingTicket(notification);

            return new AuthenticationTicket(notification.Principal, notification.Properties, notification.Options.AuthenticationScheme);
        }
    }
}
