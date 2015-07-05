using Microsoft.Framework.Internal;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNet.Authentication.Baidu
{
    internal static class BaiduAuthenticationHelper
    {
        public static string GetId([NotNull] JObject user) => user.Value<string>("uid");
        public static string GetName([NotNull] JObject user) => user.Value<string>("uname");
        public static string GetPortrait([NotNull] JObject user) => user.Value<string>("portrait");
    }
}