namespace DevZH.AspNet.Authentication.WeChat
{
    public static class WeChatDefaults
    {
        // 授权名称标识
        public const string AuthenticationScheme = "WeChat";
        // 获取 授权码 的链接
        public const string AuthorizationEndpoint = "https://open.weixin.qq.com/connect/qrconnect";
        // 获取 身份令牌 的链接
        public const string TokenEndpoint = "https://api.weixin.qq.com/sns/oauth2/access_token";
        // 获取 用户信息 的链接
        public const string UserInformationEndpoint = "https://api.weixin.qq.com/sns/userinfo";

    }
}
