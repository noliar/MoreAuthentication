namespace DevZH.AspNet.Authentication.Taobao
{
    public static class TaobaoDefaults
    {
        // 授权名称标识
        public static readonly string AuthenticationScheme = "Taobao";
        // 获取 授权码 的链接
        public static readonly string AuthorizationEndpoint = "https://oauth.taobao.com/authorize";
        // 获取相关 访问指令 的链接
        public static readonly string TokenEndpoint = "https://oauth.taobao.com/token";
    }
}
