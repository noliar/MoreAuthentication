using Microsoft.AspNet.Authentication.Common;

namespace Microsoft.AspNet.Authentication.XiaoMI
{
    public class XiaoMIAuthenticationOptions : OAuth.OAuthAuthenticationOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public XiaoMIAuthenticationOptions()
        {
            AuthenticationScheme = XiaoMIAuthenticationDefaults.AuthenticationScheme;
            Caption = AuthenticationScheme;
            CallbackPath = "/signin-mi"; // implicit
            AuthorizationEndpoint = XiaoMIAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = XiaoMIAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = XiaoMIAuthenticationDefaults.UserInformationEndpoint;
        }

        /// <summary>
        ///  小米开放平台中用 AppId 来指代 ClientId
        /// </summary>
        public string AppId
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        /// <summary>
        ///  小米开放平台中用 AppSecret 来指代 ClientSecret
        /// </summary>
        public string AppSecret
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }

        /// <summary>
        ///  指示应用是否需要用户切换账号
        /// </summary>
        /// <value>true ： 应用不需要用户切换账号</value>
        /// <value>false ： 已登录用户会进入切换账号页面</value>
        public bool SkpConfirm { get; set; }

        /// <summary>
        ///  目前 小米开放平台只支持 MAC 认证模式，文档里说未来可能支持 Bearer，时间不定
        /// </summary>
        public TokenType TokenType { get; set; } = TokenType.MAC;
    }
}
