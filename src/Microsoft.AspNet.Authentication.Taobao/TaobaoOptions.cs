using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Taobao
{
    /// <summary>
    /// 淘宝用户授权过程中所涉及到的基本信息
    /// </summary>
    public class TaobaoOptions : OAuth.OAuthOptions
    {
        /// <summary>
        ///  配置初始信息
        /// </summary>
        public TaobaoOptions()
        {
            AuthenticationScheme = TaobaoDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-taobao"; // implicit
            AuthorizationEndpoint = TaobaoDefaults.AuthorizationEndpoint;
            TokenEndpoint = TaobaoDefaults.TokenEndpoint;
        }

        /// <summary>
        ///  授权页面样式
        /// </summary>
        public enum ViewStyle
        {
            [Display(Description = "web")]
            Web,    // PC端（淘宝logo）浏览器页面样式
            [Display(Description = "tmall")]
            Tmall,  // 天猫的浏览器页面样式
            [Display(Description = "wap")]
            Wap     // 无线端的浏览器页面样式
        }

        public ViewStyle View { get; set; }
    }
}
