namespace Microsoft.AspNet.Authentication.Youku
{
    /// <summary>
    /// 优酷用户授权过程中所涉及到的基本信息
    /// </summary>
    public class YoukuAuthenticationOptions : OAuth.OAuthAuthenticationOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public YoukuAuthenticationOptions()
        {
            AuthenticationScheme = YoukuAuthenticationDefaults.AuthenticationScheme;
            Caption = AuthenticationScheme;
            CallbackPath = "/signin-youku"; // implicit
            AuthorizationEndpoint = YoukuAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = YoukuAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = YoukuAuthenticationDefaults.UserInformationEndpoint;
        }

    }
}
