using Microsoft.Framework.Internal;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.Baidu
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from Baidu after a successful authentication process.
    /// </summary>
    internal static class BaiduHelper
    {
        /// <summary>
        ///  获取百度账号 ID
        /// </summary>
        public static string GetId([NotNull] JObject user) => user.Value<string>("uid");

        /// <summary>
        ///  获取百度账号昵称
        /// </summary>
        public static string GetName([NotNull] JObject user) => user.Value<string>("uname");

        /// <summary>
        ///  获取百度账号标识，一般用来获取头像
        /// </summary>
        public static string GetPortrait([NotNull] JObject user) => user.Value<string>("portrait");
    }
}