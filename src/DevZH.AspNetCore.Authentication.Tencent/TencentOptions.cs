using DevZH.AspNetCore.Authentication.Tencent;
using Microsoft.AspNetCore.Builder;

namespace DevZH.AspNetCore.Builder
{
    public class TencentOptions : OAuthOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public TencentOptions()
        {
            AuthenticationScheme = TencentDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-qq"; // implicit
            AuthorizationEndpoint = TencentDefaults.AuthorizationEndpoint;
            TokenEndpoint = TencentDefaults.TokenEndpoint;
            UserInformationEndpoint = TencentDefaults.UserInformationEndpoint;
            OpenIdEndpoint = TencentDefaults.OpenIdEndpoint;
            Scope.Add("get_user_info");
        }

        /// <summary>
        ///  用来获取应用用户的OpenID， 腾讯开放平台中获取不到 QQ 号
        /// </summary>
        public string OpenIdEndpoint { get; }

        /// <summary>
        ///  腾讯开放平台中，用 AppId 来指代 ClientId
        /// </summary>
        public string AppId
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        /// <summary>
        ///  腾讯开放平台中，用 AppKey 来指代 ClientSecret
        /// </summary>
        public string AppKey
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }

        /// <summary>
        ///  指示授权页样式
        /// </summary>
        public bool IsMobile { get; set; }
    }
}
