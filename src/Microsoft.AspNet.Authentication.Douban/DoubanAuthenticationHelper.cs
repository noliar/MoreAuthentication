using System;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNet.Authentication.Douban
{
    internal class DoubanAuthenticationHelper
    {
        internal static string GetId(JObject payload) => payload.Value<string>("id");

        internal static string GetName(JObject payload) => payload.Value<string>("name");

        internal static string GetAvatar(JObject payload) => payload.Value<string>("avatar");

        internal static string GetUid(JObject payload) => payload.Value<string>("uid");

    }
}