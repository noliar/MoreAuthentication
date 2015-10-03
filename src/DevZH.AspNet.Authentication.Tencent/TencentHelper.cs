using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.Tencent
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from Tencent after a successful authentication process.
    /// </summary>
    internal static class TencentHelper
    {
        /// <summary>
        ///  获取 QQ 昵称
        /// </summary>
        internal static string GetName(JObject info) => info.Value<string>("nickname");

        /// <summary>
        ///  获取 QQ 头像
        /// </summary>
        internal static string GetFigure(JObject info) => info.Value<string>("figureurl_qq_1");

        /// <summary>
        ///  获取 应用账号 的 OpenID
        /// </summary>
        internal static string GetId(JObject json) => json.Value<string>("openid");
    }
}