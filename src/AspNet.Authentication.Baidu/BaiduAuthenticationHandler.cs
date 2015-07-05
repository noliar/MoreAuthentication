using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http.Extensions;
using Microsoft.AspNet.Http.Internal;
using Microsoft.AspNet.WebUtilities;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNet.Http.Authentication;
using System.Security.Claims;

namespace Microsoft.AspNet.Authentication.Baidu
{
    internal class BaiduAuthenticationHandler : OAuthAuthenticationHandler<BaiduAuthenticationOptions>
    {
        public BaiduAuthenticationHandler(HttpClient backchannel) : base(backchannel)
        {
        }

        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            return base.BuildChallengeUrl(properties, redirectUri) + "&display=" + Options.Display.GetDescription();
        }

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
    }
}