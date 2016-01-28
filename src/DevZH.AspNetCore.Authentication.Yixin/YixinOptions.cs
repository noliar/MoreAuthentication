using DevZH.AspNetCore.Authentication.Yixin;
using Microsoft.AspNetCore.Builder;

namespace DevZH.AspNetCore.Builder
{
    /// <summary>
    /// 易信用户授权过程中所涉及到的基本信息
    /// </summary>
    public class YixinOptions : OAuthOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public YixinOptions()
        {
            AuthenticationScheme = YixinDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-yixin"; // implicit
            AuthorizationEndpoint = YixinDefaults.AuthorizationEndpoint;
            TokenEndpoint = YixinDefaults.TokenEndpoint;
            UserInformationEndpoint = YixinDefaults.UserInformationEndpoint;
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
