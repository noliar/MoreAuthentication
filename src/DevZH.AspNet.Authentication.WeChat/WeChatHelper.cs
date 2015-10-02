using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.WeChat
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from WeChat after a successful authentication process.
    /// </summary>
    internal static class WeChatHelper
    {
        /// <summary>
        /// 微信普通用户昵称
        /// </summary>
        internal static string GetNick(JObject payload)
         => payload.Value<string>("nickname");

        /// <summary>
        /// 微信用户头像
        /// </summary>
        /// <remarks>
        /// 最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
        /// </remarks>
        internal static string GetHeadImage(JObject payload)
        => payload.Value<string>("headimgurl");
    }
}