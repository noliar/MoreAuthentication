namespace DevZH.AspNet.Authentication.Sina
{
    public static class SinaDefaults
    {
        // 授权名称标识
        public const string AuthenticationScheme = "Sina";
        // 认证及获取临时 code 的链接
        public const string AuthorizationEndpoint = "https://api.weibo.com/oauth2/authorize";
        // 认证及获取临时 code 的链接（手机版）
        public const string AuthorizationEndpointMobile = "https://open.weibo.cn/oauth2/authorize";
        // 获取 token 及 uid 的链接
        public const string TokenEndpoint = "https://api.weibo.com/oauth2/access_token";
        // 获取 uid 的链接，这里没用
        public const string UserInformationEndpoint = "https://api.weibo.com/2/account/get_uid.json";
    }
}
