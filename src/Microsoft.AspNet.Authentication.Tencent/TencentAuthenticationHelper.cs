using Newtonsoft.Json.Linq;

namespace Microsoft.AspNet.Authentication.Tencent
{
    internal class TencentAuthenticationHelper
    {
        internal static string GetNickName(JObject info) => info.Value<string>("nickname");

        internal static string GetFigure(JObject info) => info.Value<string>("figureurl_qq_1");

        internal static string GetOpenId(JObject json) => json.Value<string>("openid");
    }
}