namespace Microsoft.AspNet.Authentication.Yixin
{
    /// <summary>
    /// 易信用户授权过程中所涉及到的基本信息
    /// </summary>
    public class YixinAuthenticationOptions : OAuth.OAuthAuthenticationOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public YixinAuthenticationOptions()
        {
            AuthenticationScheme = YixinAuthenticationDefaults.AuthenticationScheme;
            Caption = AuthenticationScheme;
            CallbackPath = "/signin-yixin"; // implicit
            AuthorizationEndpoint = YixinAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = YixinAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = YixinAuthenticationDefaults.UserInformationEndpoint;
        }

        /// <summary>
        ///  易信开放平台一般都用 AppId 来指代 ClientId
        /// </summary>
        public string AppId
        {
            get
            {
                return ClientId;
            }
            set
            {
                ClientId = value;
            }
        }

        /// <summary>
        ///  易信开放平台一般都用 AppSecret 来指代 ClientSecret
        /// </summary>
        public string AppSecret
        {
            get
            {
                return ClientSecret;
            }
            set
            {
                ClientSecret = value;
            }
        }
    }
}
