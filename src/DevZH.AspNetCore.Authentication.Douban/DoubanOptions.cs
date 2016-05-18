using DevZH.AspNetCore.Authentication.Douban;
using Microsoft.AspNetCore.Builder;

namespace DevZH.AspNetCore.Builder
{
    /// <summary>
    /// 豆瓣用户授权过程中所涉及到的基本信息
    /// </summary>
    public class DoubanOptions : OAuthOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public DoubanOptions()
        {
            AuthenticationScheme = DoubanDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-douban"; // implicit
            AuthorizationEndpoint = DoubanDefaults.AuthorizationEndpoint;
            TokenEndpoint = DoubanDefaults.TokenEndpoint;
            UserInformationEndpoint = DoubanDefaults.UserInformationEndpoint;
            Scope.Add("douban_basic_common");
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
