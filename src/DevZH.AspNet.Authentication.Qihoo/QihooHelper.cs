using System;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.Qihoo
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from Qihoo 360 after a successful authentication process.
    /// </summary>
    public static class QihooHelper
    {
        /// <summary>
        ///  360 用户ID
        /// </summary>
        public static string GetId(JObject payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            return payload.Value<string>("id");
        }

        /// <summary>
        ///  360 用户名
        /// </summary>
        public static string GetName(JObject payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            return payload.Value<string>("name");
        }

        /// <summary>
        ///  360 用户头像
        /// </summary>
        public static string GetAvatar(JObject payload) => payload.Value<string>("avatar");
    }
}