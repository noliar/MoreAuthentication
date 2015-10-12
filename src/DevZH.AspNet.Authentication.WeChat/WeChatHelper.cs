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
        ///  微信用户 OpenId
        /// </summary>
        /// <remarks>
        ///  微信获取不到具体的微信号或 QQ 号，对于每个应用而言，用 OpenId 来识别不同的用户。
        ///  所以以此来替代 Id。
        /// </remarks>
        internal static string GetId(JObject payload)
         => payload.Value<string>("openid");

        /// <summary>
        /// 微信普通用户昵称
        /// </summary>
        // 方法名为了统一，国内常见的都是用昵称来显示名称。
        internal static string GetName(JObject payload)
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