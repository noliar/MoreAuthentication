using Microsoft.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Baidu
{
    /// <summary>
    ///  一些扩展方法
    /// </summary>
    public static class BaiduAuthenticationExtensions
    {
        // 获取 display style 的名称
        public static string GetDescription([NotNull] this BaiduAuthenticationOptions.DisplayStyle style)
        {
            // DNX CORE do not support Type.GetMember(string name); So use switch instead
            // 不知道为啥，dnx core 就是访问不了 mscorelib(7cec85d7bea7798e) 里的东西，
            // 明明里面有啊。不知道是 BUG，还是啥
            switch (style)
            {
                case BaiduAuthenticationOptions.DisplayStyle.Dialog:
                    return "dialog";
                case BaiduAuthenticationOptions.DisplayStyle.Mobile:
                    return "mobile";
                case BaiduAuthenticationOptions.DisplayStyle.Popup:
                    return "popup";
                case BaiduAuthenticationOptions.DisplayStyle.Pad:
                    return "pad";
                case BaiduAuthenticationOptions.DisplayStyle.Touch:
                    return "touch";
                case BaiduAuthenticationOptions.DisplayStyle.TV:
                    return "tv";
                case BaiduAuthenticationOptions.DisplayStyle.WeiboPage:
                    return "weibo_page";
                default:
                    return "page";
            }
        }
    }
}
