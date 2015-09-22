using Newtonsoft.Json.Linq;

namespace Microsoft.AspNet.Authentication.XiaoMi
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from Xiao MI after a successful authentication process.
    /// </summary>
    internal class XiaoMiHelper
    {
        /// <summary>
        ///  获取米聊 ID
        /// </summary>
        internal static string GetId(JObject payload) => payload["data"].Value<string>("userId");

        /// <summary>
        ///  获取米聊昵称
        /// </summary>
        internal static string GetNickName(JObject payload) => payload["data"].Value<string>("miliaoNick");

        /// <summary>
        ///  获取米聊头像
        /// </summary>
        internal static string GetIcon(JObject payload) => payload["data"].Value<string>("miliaoIcon");
    }
}