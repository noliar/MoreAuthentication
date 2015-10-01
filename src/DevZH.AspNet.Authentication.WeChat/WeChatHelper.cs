using System;
using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.WeChat
{
    internal class WeChatHelper
    {
        internal static string GetNick(JObject payload)
         => payload.Value<string>("nickname");

        internal static string GetHeadImage(JObject payload)
        => payload.Value<string>("headimgurl");
    }
}