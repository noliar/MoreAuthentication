using System;
using System.ComponentModel.DataAnnotations;
using DevZH.AspNetCore.Authentication.Qihoo;

namespace DevZH.AspNetCore.Builder
{
    /// <summary>
    /// Configuration options for <see cref="QihooMiddleware" />.
    /// </summary>
    public class QihooOptions : OAuthOptions
    {
        /// <summary>
        /// 一些默认设置
        /// </summary>
        public QihooOptions()
        {
            AuthenticationScheme = QihooDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-qihoo";
            AuthorizationEndpoint = QihooDefaults.AuthorizationEndpoint;
            TokenEndpoint = QihooDefaults.TokenEndpoint;
            UserInformationEndpoint = QihooDefaults.UserInformationEndpoint;
        }

        /// <summary>
        ///  360登录和授权页面的样式；
        /// </summary>
        public enum DisplayStyle : byte
        {
            [Display(Description = "default")]
            Default,                    // 默认的授权页面
            [Display(Description = "desktop")]
            Desktop                     // 适用于 360 桌面应用的授权页面
        }

        public DisplayStyle Display { get; set; }

        /// <summary>
        /// 仅在实现"使用360账号登陆"功能时才需要传递。当浏览器有 360cookie 时，设置 <see cref="ReLogin"/> 用来展示“当前账号登陆确认页”
        /// </summary>
        /// <value>公司域名</value>
        /// <example>若公司网址为 www.360.cn，则可设置 <see cref="ReLogin"/> 值为 360.cn</example>
        public string ReLogin { get; set; }

        /// <summary>
        /// OAuth 版本号
        /// </summary>
        /// <remarks>
        /// 如果填写必须为 1.0（文档这样说，试了下，好像没区别，明明用的是 OAuth2.0）
        /// </remarks>
        [Obsolete("忽略该参数")]
        public string OAuthVersion { get; set; }

        /// <summary>
        ///  360 账号授权中，用 <see cref="AppKey"/> 来指代 <see cref="OAuthOptions.ClientId"/>
        /// </summary>
        public string AppKey
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        /// <summary>
        ///  360 账号授权中，用 <see cref="AppSecret"/> 来指代 <see cref="OAuthOptions.ClientSecret"/>
        /// </summary>
        public string AppSecret
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }
    }
}
