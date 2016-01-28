using DevZH.AspNetCore.Authentication.WeChat;

namespace DevZH.AspNetCore.Builder
{
    public class WeChatOptions : OAuthOptions
    {
        public WeChatOptions()
        {
            AuthenticationScheme = WeChatDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-wechat";
            AuthorizationEndpoint = WeChatDefaults.AuthorizationEndpoint;
            TokenEndpoint = WeChatDefaults.TokenEndpoint;
            UserInformationEndpoint = WeChatDefaults.UserInformationEndpoint;
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
