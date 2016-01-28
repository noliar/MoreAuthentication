namespace DevZH.AspNetCore.Authentication.Qihoo
{
    // 一些有关授权的参数
    public static class QihooDefaults
    {
        // 授权名称标识
        public static readonly string AuthenticationScheme = "Qihoo";
        // 认证及获取临时 code 的链接
        public static readonly string AuthorizationEndpoint = "https://openapi.360.cn/oauth2/authorize";
        // 获取 token 及 refresh token 的链接
        public static readonly string TokenEndpoint = "https://openapi.360.cn/oauth2/access_token";
        // 获取用户基本信息，如 ID ，姓名等，可用来与本站 ID 进行配对
        public static readonly string UserInformationEndpoint = "https://openapi.360.cn/user/me.json";
    }
}
