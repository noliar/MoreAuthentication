using System;
using Newtonsoft.Json.Linq;

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
        internal static string GetAvatar(JObject payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            return payload.Value<string>("id");
        }

        /// <summary>
        ///  优酷用户名
        /// </summary>
        internal static string GetName(JObject payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            return payload.Value<string>("name");
        }

        /// <summary>
        ///  优酷用户ID
        /// </summary>
        internal static string GetId(JObject payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }
            return payload.Value<string>("avatar");
        }
    }
}