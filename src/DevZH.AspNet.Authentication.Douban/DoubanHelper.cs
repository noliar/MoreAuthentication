using System;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.Douban
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from Douban after a successful authentication process.
    /// </summary>
    internal class DoubanHelper
    {
        /// <summary>
        ///  获取用户 ID
        /// </summary>
        internal static string GetId(JObject payload) => payload.Value<string>("id");

        /// <summary>
        ///  获取用户 名称
        /// </summary>
        internal static string GetName(JObject payload) => payload.Value<string>("name");

        /// <summary>
        ///  获取用户 头像
        /// </summary>
        internal static string GetAvatar(JObject payload) => payload.Value<string>("avatar");

        /// <summary>
        ///  获取用户 uid
        /// </summary>
        internal static string GetUid(JObject payload) => payload.Value<string>("uid");

    }
}