using System;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNetCore.Authentication.XiaoMi
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from Xiao MI after a successful authentication process.
    /// </summary>
    internal static class XiaoMiHelper
    {
        /// <summary>
        ///  获取米聊用户 OpenId
        /// </summary>
        // 因为有了 Id 所以就不用 OpenId 来指代了。
        internal static string GetOpenId(JObject payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            return payload.Value<string>("openId");
        }

        /// <summary>
        ///  获取米聊 ID
        /// </summary>
        internal static string GetId(JObject payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            return payload["data"].Value<string>("userId");
        }

        /// <summary>
        ///  获取米聊昵称
        /// </summary>
        internal static string GetName(JObject payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            return payload["data"].Value<string>("miliaoNick");
        }

        /// <summary>
        ///  获取米聊头像
        /// </summary>
        internal static string GetIcon(JObject payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            return payload["data"].Value<string>("miliaoIcon");
        }
    }
}