namespace Microsoft.AspNet.Authentication.Douban
{
    /// <summary>
    /// 豆瓣用户授权过程中所涉及到的基本信息
    /// </summary>
    public class DoubanAuthenticationOptions : OAuth.OAuthAuthenticationOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public DoubanAuthenticationOptions()
        {
            AuthenticationScheme = DoubanAuthenticationDefaults.AuthenticationScheme;
            Caption = AuthenticationScheme;
            CallbackPath = "/signin-douban"; // implicit
            AuthorizationEndpoint = DoubanAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = DoubanAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = DoubanAuthenticationDefaults.UserInformationEndpoint;
        }

        /// <summary>
        ///  豆瓣开放平台中，用 ApiKey 来指代 ClientId
        /// </summary>
        public string ApiKey
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        /// <summary>
        ///  豆瓣开放平台中，用 Secret 来指代 ClientSecret
        /// </summary>
        public string Secret
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }
    }
}
