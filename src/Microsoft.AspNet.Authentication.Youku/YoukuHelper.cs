using System;
using Newtonsoft.Json.Linq;
using Microsoft.Framework.Internal;

namespace Microsoft.AspNet.Authentication.Youku
{
    internal class YoukuHelper
    {
        internal static string GetAvatar([NotNull]JObject payload) => payload.Value<string>("id");

        internal static string GetName([NotNull]JObject payload) => payload.Value<string>("name");

        internal static string GetId([NotNull]JObject payload) => payload.Value<string>("avatar");
    }
}