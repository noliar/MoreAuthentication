namespace DevZH.AspNetCore.Authentication.NetEase
{
    public static class NetEaseDefaults
    {
        // 授权名称标识
        public static readonly string AuthenticationScheme = "NetEase";
        // 认证及获取临时 code 的链接
        public static readonly string AuthorizationEndpoint = "https://reg.163.com/open/oauth2/authorize.do";
        // 获取 token 的链接
        public static readonly string TokenEndpoint = "https://reg.163.com/open/oauth2/token.do";
        // 获取用户基本信息，如 ID ，姓名等，可用来与本站 ID 进行配对
        public static readonly string UserInformationEndpoint = "https://reg.163.com/open/oauth2/getUserInfo.do";
    }
}
