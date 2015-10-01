namespace DevZH.AspNet.Authentication.Taobao
{
    public class TaobaoDefaults
    {
        // 授权名称标识
        public const string AuthenticationScheme = "Taobao";
        // 获取 授权码 的链接
        public const string AuthorizationEndpoint = "https://oauth.taobao.com/authorize";
        // 获取相关 访问指令 的链接
        public const string TokenEndpoint = "https://oauth.taobao.com/token";
    }
}
