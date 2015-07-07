using System;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNet.Authentication.Yixin
{
    internal class YixinAuthenticationHelper
    {
        internal static string GetId(JObject payload) => payload["userinfo"]?.Value<string>("accountId");

        internal static string GetName(JObject payload) => payload["userinfo"]?.Value<string>("nick");

        internal static string GetIcon(JObject payload) => payload["userinfo"]?.Value<string>("icon");
    }
}