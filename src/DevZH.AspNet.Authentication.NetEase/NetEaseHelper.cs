using System;
using Microsoft.Framework.Internal;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.NetEase
{
    internal static class NetEaseHelper
    {
        internal static string GetId([NotNull] JObject user) => user.Value<string>("userId");

        internal static string GetName([NotNull] JObject user) => user.Value<string>("username");
    }
}