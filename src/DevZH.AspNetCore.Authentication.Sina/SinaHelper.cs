using System;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNetCore.Authentication.Sina
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
        public static string GetId(JObject payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            return payload.Value<string>("uid");
        }
    }
}
