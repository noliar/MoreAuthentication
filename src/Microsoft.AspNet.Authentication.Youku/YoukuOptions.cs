namespace Microsoft.AspNet.Authentication.Youku
{
    /// <summary>
    /// 优酷用户授权过程中所涉及到的基本信息
    /// </summary>
    public class YoukuOptions : OAuth.OAuthOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public YoukuOptions()
        {
            AuthenticationScheme = YoukuDefaults.AuthenticationScheme;
            Caption = AuthenticationScheme;
            CallbackPath = "/signin-youku"; // implicit
            AuthorizationEndpoint = YoukuDefaults.AuthorizationEndpoint;
            TokenEndpoint = YoukuDefaults.TokenEndpoint;
            UserInformationEndpoint = YoukuDefaults.UserInformationEndpoint;
        }

    }
}
