namespace DevZH.AspNet.Authentication.Baidu
{
    public static class BaiduDefaults
    {
        // 授权名称标识
        public static readonly string AuthenticationScheme = "Baidu";
        // 认证及获取临时 code 的链接
        public static readonly string AuthorizationEndpoint = "https://openapi.baidu.com/oauth/2.0/authorize";
        // 获取 token 及 refresh token 的链接
        public static readonly string TokenEndpoint = "https://openapi.baidu.com/oauth/2.0/token";
        // 获取用户基本信息，如 ID ，姓名等，可用来与本站 ID 进行配对
        // public const string UserInformationEndpoint = "https://openapi.baidu.com/rest/2.0/passport/users/getInfo";
        public static readonly string UserInformationEndpoint = "https://openapi.baidu.com/rest/2.0/passport/users/getLoggedInUser";
    }
}
