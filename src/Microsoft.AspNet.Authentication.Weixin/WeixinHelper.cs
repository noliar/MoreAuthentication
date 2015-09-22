using System;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNet.Authentication.Weixin
{
    internal class WeixinHelper
    {
        internal static string GetNick(JObject payload)
         => payload.Value<string>("nickname");

        internal static string GetHeadImage(JObject payload)
        => payload.Value<string>("headimgurl");
    }
}