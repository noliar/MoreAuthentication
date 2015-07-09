using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Tencent
{
    public class TencentAuthenticationOptions : OAuth.OAuthAuthenticationOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public TencentAuthenticationOptions()
        {
            AuthenticationScheme = TencentAuthenticationDefaults.AuthenticationScheme;
            Caption = AuthenticationScheme;
            CallbackPath = "/signin-qq"; // implicit
            AuthorizationEndpoint = TencentAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = TencentAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = TencentAuthenticationDefaults.UserInformationEndpoint;
            OpenIdEndpoint = TencentAuthenticationDefaults.OpenIdEndpoint;
        }

        /// <summary>
        ///  获取应用用户的OpenID， 腾讯开放平台中获取不到 QQ 号
        /// </summary>
        public string OpenIdEndpoint { get; set; }

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
