using DevZH.AspNetCore.Authentication.NetEase;

namespace DevZH.AspNetCore.Builder
{
    /// <summary>
    /// Configuration options for <see cref="NetEaseMiddleware" />.
    /// </summary>
    public class NetEaseOptions : OAuthOptions
    {
        /// <summary>
        /// 一些默认设置
        /// </summary>
        public NetEaseOptions()
        {
            AuthenticationScheme = NetEaseDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-netease";
            AuthorizationEndpoint = NetEaseDefaults.AuthorizationEndpoint;
            TokenEndpoint = NetEaseDefaults.TokenEndpoint;
            UserInformationEndpoint = NetEaseDefaults.UserInformationEndpoint;
        }

        /// <summary>
        ///  网易邮箱授权中，用 Key 来指代 ClientId
        /// </summary>
        public string Key
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        /// <summary>
        ///  网易邮箱授权中，用 Secret 来指代 ClientSecret
        /// </summary>
        public string Secret
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }
    }
}
