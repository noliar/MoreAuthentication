using System;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.NetEase
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from NetEase after a successful authentication process.
    /// </summary>
    internal static class NetEaseHelper
    {
        /// <summary>
        ///  获取用户 ID
        /// </summary>
        internal static string GetId(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("userId");
        }

        /// <summary>
        ///  获取用户名称
        /// </summary>
        internal static string GetName(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("username");
        }
    }
}