using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http;

namespace DevZH.AspNet.Authentication.Sina
{
    /// <summary>
    /// 新浪用户授权过程中所涉及到的基本信息
    /// </summary>
    public class SinaOptions : OAuthOptions
    {
        private DisplayStyle _display;

        /// <summary>
        ///  配置初始信息
        /// </summary>
        public SinaOptions()
        {
            AuthenticationScheme = SinaDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/signin-sina");
            AuthorizationEndpoint = SinaDefaults.AuthorizationEndpoint;
            TokenEndpoint = SinaDefaults.TokenEndpoint;
            UserInformationEndpoint = SinaDefaults.UserInformationEndpoint;
        }

        /// <summary>
        ///  授权页面的终端类型
        /// </summary>
        public enum DisplayStyle : byte
        {
            [Display(Description = "default")]
            Default,    // 默认的授权页面，适用于web浏览器。
            [Display(Description = "mobile")]
            Mobile,     // 移动终端的授权页面，适用于支持html5的手机。
            [Display(Description = "wap")]
            Wap,        // wap版授权页面，适用于非智能手机。
            [Display(Description = "client")]
            Client,     // 客户端版本授权页面，适用于PC桌面应用。
            [Display(Description = "apponweibo")]
            AppOnWeibo  // 默认的站内应用授权页，授权后不返回access_token，只刷新站内应用父框架。
        }

        public DisplayStyle Display {
            get
            {
                return _display;
            }
            set
            {
                _display = value;
                // 当授权页面样式为 mobile 时，官方文档建议使用 https://open.weibo.cn/oauth2/authorize 授权接口
                AuthorizationEndpoint =
                    _display == DisplayStyle.Mobile
                  ? SinaDefaults.AuthorizationEndpointMobile
                  : SinaDefaults.AuthorizationEndpoint;
            }
        }

        /// <summary>
        ///  语言样式，英文为测试版。
        /// </summary>
        public enum LanguageType : byte
        {
            Chinese,
            English
        }

        public LanguageType Language { get; set; }

        /// <summary>
        ///  表示是否强制登录。
        /// <value> true 则表示需要强制登陆</value>
        /// </summary>
        public bool IsForce { get; set; }

        /// <summary>
        ///  新浪开放平台一般都用 AppKey 来指代 ClientId
        /// </summary>
        public string AppKey
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        /// <summary>
        ///  新浪开放平台一般都用 AppSecret 来指代 ClientSecret
        /// </summary>
        public string AppSecret
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }
    }
}
