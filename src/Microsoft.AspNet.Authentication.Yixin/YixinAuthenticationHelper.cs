using System;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNet.Authentication.Yixin
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from Yixin after a successful authentication process.
    /// </summary>
    internal class YixinAuthenticationHelper
    {
        /// <summary>
        ///  获取易信账号 ID
        /// </summary>
        internal static string GetId(JObject payload) => payload["userinfo"]?.Value<string>("accountId");

        /// <summary>
        ///  获取易信昵称
        /// </summary>
        internal static string GetName(JObject payload) => payload["userinfo"]?.Value<string>("nick");

        /// <summary>
        ///  获取易信用户头像
        /// </summary>
        internal static string GetIcon(JObject payload) => payload["userinfo"]?.Value<string>("icon");
    }
}