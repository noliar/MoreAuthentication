namespace DevZH.AspNet.Authentication.XiaoMi
{
    public static class XiaoMiDefaults
    {
        // 授权名称标识
        public const string AuthenticationScheme = "XiaoMi";
        // 请求用户授权接口
        public const string AuthorizationEndpoint = "https://account.xiaomi.com/oauth2/authorize";
        // 获取访问令牌接口
        public const string TokenEndpoint = "https://account.xiaomi.com/oauth2/token";
        // 获取用户名片
        public const string UserInformationEndpoint = "https://open.account.xiaomi.com/user/profile";
    }
}
