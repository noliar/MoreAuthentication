using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Weixin
{
    public class WeixinOptions : OAuth.OAuthOptions
    {
        public WeixinOptions()
        {
            AuthenticationScheme = WeixinDefaults.AuthenticationScheme;
            Caption = AuthenticationScheme;
            CallbackPath = "/signin-weixin";
            AuthorizationEndpoint = WeixinDefaults.AuthorizationEndpoint;
            TokenEndpoint = WeixinDefaults.TokenEndpoint;
            UserInformationEndpoint = WeixinDefaults.UserInformationEndpoint;
        }

        /// <summary>
        ///  微信开放平台中以 AppId 代替 常规的 ClientId
        /// </summary>
        public string AppId
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        /// <summary>
        ///  微信开放平台中以 AppSecret 代替 常规的 ClientSecret
        /// </summary>
        public string AppSecret
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }
    }
}
