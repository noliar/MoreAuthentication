namespace DevZH.AspNetCore.Authentication.Yixin
{
    public static class YixinDefaults
    {
        // 授权名称标识
        public static readonly string AuthenticationScheme = "Yixin";
        // 认证及获取临时 code 的链接
        public static readonly string AuthorizationEndpoint = "https://open.yixin.im/oauth/authorize";
        // 获取相关 token 的链接
        public static readonly string TokenEndpoint = "https://open.yixin.im/oauth/token";
        // 获取 用户基本信息 的链接
        public static readonly string UserInformationEndpoint = "https://open.yixin.im/api/userinfo";
    }
}
