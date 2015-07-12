using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Taobao
{
    public class TaobaoAuthenticationDefaults
    {
        // 授权名称标识
        public const string AuthenticationScheme = "Taobao";
        // 获取 授权码 的链接
        public const string AuthorizationEndpoint = "https://oauth.taobao.com/authorize";
        // 获取相关 访问指令 的链接
        public const string TokenEndpoint = "https://oauth.taobao.com/token";
    }
}
