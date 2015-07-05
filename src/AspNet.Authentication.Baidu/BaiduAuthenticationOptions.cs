using Microsoft.AspNet.Authentication.OAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Baidu
{
    public class BaiduAuthenticationOptions : OAuthAuthenticationOptions
    {
        public BaiduAuthenticationOptions()
        {
            AuthenticationScheme = BaiduAuthenticationDefaults.AuthenticationScheme;
            Caption = AuthenticationScheme;
            CallbackPath = new Http.PathString("/signin-baidu");
            AuthorizationEndpoint = BaiduAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = BaiduAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = BaiduAuthenticationDefaults.UserInformationEndpoint;
            SaveTokensAsClaims = false;
        }

        public enum DisplayStyle
        {
            //[Description("page")]
            Page,                    // 全屏形式的授权页面(默认)，适用于web应用。
            //[Description("popup")]
            Popup,                   // 弹框形式的授权页面，适用于桌面软件应用和web应用。
            //[Description("dialog")]
            Dialog,                  // 浮层形式的授权页面，只能用于站内web应用。
            //[Description("mobile")]
            Mobile,                  // 普通移动终端的授权页面，适用于普通的移动终端上的wap站点
            //[Description("touch")]
            Touch,                   // iPhone/Android等智能移动终端上用的授权页面，适用于iPhone/Android等智能移动终端上的应用。
            //[Description("tv")]
            TV,                      // 电视等超大显示屏使用的授权页面。
            //[Description("pad")]
            Pad,                     // iPad/Android等平板上使用的授权页面，适用于iPad/Android等智能移动终端上的应用。
            //[Description("weibo_page")]
            WeiboPage,               // 仅用于 新浪微博 的登录授权。
            //[Description("page")]
            Default = Page           // 默认授权页面样式为 全屏
        }

        public DisplayStyle Display { get; set; }
    }
}
