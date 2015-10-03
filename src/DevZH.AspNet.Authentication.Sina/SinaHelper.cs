using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.Sina
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from Sina after a successful authentication process.
    /// </summary>
    public static class SinaHelper
    {
        /// <summary>
        ///  新浪微博用户ID
        /// </summary>
        public static string GetId(JObject payload) => payload.Value<string>("uid");
    }
}
