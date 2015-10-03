using Newtonsoft.Json.Linq;

namespace DevZH.AspNet.Authentication.Taobao
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from Taobao after a successful authentication process.
    /// </summary>
    public static class TaobaoHelper
    {
        /// <summary>
        ///  淘宝帐号对应id
        /// </summary>
        public static string GetId(JObject payload) => payload.Value<string>("taobao_user_id");

        /// <summary>
        ///  淘宝账号
        /// </summary>
        // 文档显示：其结果是经过URI编码的结果，所以在这里我将其解码
        public static string GetName(JObject payload) => System.Uri.UnescapeDataString(payload.Value<string>("taobao_user_nick"));
    }
}
