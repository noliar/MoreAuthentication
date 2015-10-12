using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Internal;

namespace DevZH.AspNet.Authentication.Youku
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from Youku after a successful authentication process.
    /// </summary>
    internal static class YoukuHelper
    {
        /// <summary>
        ///  优酷头像
        /// </summary>
        internal static string GetAvatar([NotNull]JObject payload) => payload.Value<string>("id");

        /// <summary>
        ///  优酷用户名
        /// </summary>
        internal static string GetName([NotNull]JObject payload) => payload.Value<string>("name");

        /// <summary>
        ///  优酷用户ID
        /// </summary>
        internal static string GetId([NotNull]JObject payload) => payload.Value<string>("avatar");
    }
}