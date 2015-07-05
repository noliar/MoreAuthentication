using Microsoft.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Baidu
{
    public static class BaiduAuthenticationExtensions
    {
        internal static string GetDescription([NotNull] this BaiduAuthenticationOptions.DisplayStyle style)
        {
            // DNX CORE do not support Type.GetMember(string name); So use switch instead
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
