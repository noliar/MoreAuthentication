using DevZH.AspNetCore.Authentication.Youku;

namespace DevZH.AspNetCore.Builder
{
    /// <summary>
    /// 优酷用户授权过程中所涉及到的基本信息
    /// </summary>
    public class YoukuOptions : OAuthOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public YoukuOptions()
        {
            AuthenticationScheme = YoukuDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-youku"; // implicit
            AuthorizationEndpoint = YoukuDefaults.AuthorizationEndpoint;
            TokenEndpoint = YoukuDefaults.TokenEndpoint;
            UserInformationEndpoint = YoukuDefaults.UserInformationEndpoint;
        }

    }
}
