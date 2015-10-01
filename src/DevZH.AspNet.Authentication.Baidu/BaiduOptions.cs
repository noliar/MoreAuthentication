using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DevZH.AspNet.Authentication.Baidu
{
    /// <summary>
    /// Configuration options for <see cref="BaiduMiddleware" />.
    /// </summary>
    public class BaiduOptions : OAuthOptions
    {
        /// <summary>
        /// 一些默认设置
        /// </summary>
        public BaiduOptions()
        {
            AuthenticationScheme = BaiduDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/signin-baidu");
            AuthorizationEndpoint = BaiduDefaults.AuthorizationEndpoint;
            TokenEndpoint = BaiduDefaults.TokenEndpoint;
            UserInformationEndpoint = BaiduDefaults.UserInformationEndpoint;
            SaveTokensAsClaims = false;
        }

        /// <summary>
        ///  百度授权页面的样式；一般来说，这些够用了，不像 scope，权限很杂，很多都要另外申请
        /// </summary>
        public enum DisplayStyle : byte
        {
            [Display(Description = "page")]
            Page,                    // 全屏形式的授权页面(默认)，适用于web应用。
            [Display(Description = "popup")]
            Popup,                   // 弹框形式的授权页面，适用于桌面软件应用和web应用。
            [Display(Description = "dialog")]
            Dialog,                  // 浮层形式的授权页面，只能用于站内web应用。
            [Display(Description = "mobile")]
            Mobile,                  // 普通移动终端的授权页面，适用于普通的移动终端上的wap站点
            [Display(Description = "touch")]
            Touch,                   // iPhone/Android等智能移动终端上用的授权页面，适用于iPhone/Android等智能移动终端上的应用。
            [Display(Description = "tv")]
            Television,                      // 电视等超大显示屏使用的授权页面。
            [Display(Description = "pad")]
            Pad,                     // iPad/Android等平板上使用的授权页面，适用于iPad/Android等智能移动终端上的应用。
            [Display(Description ="weibo_page")]
            WeiboPage,               // 仅用于 新浪微博 的登录授权。
        }

        public DisplayStyle Display { get; set; }

        /// <summary>
        ///  表示 redirect_uri 参数 是否为 oob；
        ///  目前，不推荐这么做
        ///  TODO 但十分有可能是删掉
        /// </summary>
        [Obsolete("没想好网页上怎么搞比较恰当", true)]
        public bool IsOob { get; set; }

        /// <summary>
        ///  是否强制用户输入。
        /// <value> true 则表示加载登录页时强制用户输入用户名和口令，不会从cookie中读取百度用户的登陆状态</value>
        /// </summary>
        public bool IsForce { get; set; }

        /// <summary>
        ///  需要用户手动授权。
        /// <value>
        ///  当百度用户已处于登陆状态，true 则表示要提示是否使用已当前登陆用户对应用授权
        /// </value>
        /// </summary>
        public bool IsConfirm { get; set; } = true;

        /// <summary>
        ///  是否启用短信动态指令注册和登录。
        /// <value> true 则表示，当需要注册和登录时，授权页面会默认使用短信动态密码。</value>
        /// </summary>
        public bool UseSms { get; set; }

        /// <summary>
        ///  百度开放云上用 AccessKeyId 来指代 ClientId。
        /// </summary>
        /// <remarks>
        ///  相当于，百度开放平台中的 ApiKey
        /// </remarks>
        public string AccessKeyId
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        /// <summary>
        ///  百度开放云上用 SecretAccessKey 来指代 ClientSecret。
        /// </summary>
        /// <remarks>
        ///  相当于，百度开放平台中的 SecretKey
        /// </remarks>
        public string SecretAccessKey
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }
    }
}
