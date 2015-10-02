namespace DevZH.AspNet.Authentication.NetEase
{
    public static class NetEaseDefaults
    {
        // 授权名称标识
        public const string AuthenticationScheme = "NetEase";
        // 认证及获取临时 code 的链接
        public const string AuthorizationEndpoint = "https://reg.163.com/open/oauth2/authorize.do";
        // 获取 token 的链接
        public const string TokenEndpoint = "https://reg.163.com/open/oauth2/token.do";
        // 获取用户基本信息，如 ID ，姓名等，可用来与本站 ID 进行配对
        public const string UserInformationEndpoint = "https://reg.163.com/open/oauth2/getUserInfo.do";
    }
}
