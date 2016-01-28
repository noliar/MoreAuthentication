namespace DevZH.AspNetCore.Authentication.Sina
{
    public static class SinaDefaults
    {
        // 授权名称标识
        public static readonly string AuthenticationScheme = "Sina";
        // 认证及获取临时 code 的链接
        public static readonly string AuthorizationEndpoint = "https://api.weibo.com/oauth2/authorize";
        // 认证及获取临时 code 的链接（手机版）
        public static readonly string AuthorizationEndpointMobile = "https://open.weibo.cn/oauth2/authorize";
        // 获取 token 及 uid 的链接
        public static readonly string TokenEndpoint = "https://api.weibo.com/oauth2/access_token";
        // 获取 uid 的链接，这里没用
        public static readonly string UserInformationEndpoint = "https://api.weibo.com/2/account/get_uid.json";
        // public const string UserInformationEndpoint = "https://api.weibo.com/2/users/show.json?access_token={0}&uid={1}";
    }
}
