using Microsoft.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevZH.AspNet.Authentication.Baidu
{
    /// <summary>
    ///  一些扩展方法
    /// </summary>
    public static class BaiduExtensions
    {
        // 获取 display style 的名称
        /*public static string GetDescription([NotNull] this BaiduOptions.DisplayStyle style)
        {
            // DNX CORE do not support Type.GetMember(string name); So use switch instead
            // 不知道为啥，dnx core 就是访问不了 mscorelib(7cec85d7bea7798e) 里的东西，
            // 明明里面有啊。不知道是 BUG，还是啥
            switch (style)
            {
                case BaiduOptions.DisplayStyle.Dialog:
                    return "dialog";
                case BaiduOptions.DisplayStyle.Mobile:
                    return "mobile";
                case BaiduOptions.DisplayStyle.Popup:
                    return "popup";
                case BaiduOptions.DisplayStyle.Pad:
                    return "pad";
                case BaiduOptions.DisplayStyle.Touch:
                    return "touch";
                case BaiduOptions.DisplayStyle.TV:
                    return "tv";
                case BaiduOptions.DisplayStyle.WeiboPage:
                    return "weibo_page";
                default:
                    return "page";
            }
        }*/
    }
}
