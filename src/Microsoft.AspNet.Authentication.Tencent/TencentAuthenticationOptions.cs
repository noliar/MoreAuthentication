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

        public string OpenIdEndpoint { get; set; }

        public string AppId
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        public string AppKey
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }

        public bool IsMobile { get; set; }
    }
}
