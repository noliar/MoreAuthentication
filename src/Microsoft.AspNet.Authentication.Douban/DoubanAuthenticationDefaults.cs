using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Douban
{
    public class DoubanAuthenticationDefaults
    {
        // 授权名称标识
        public const string AuthenticationScheme = "Douban";
        // 认证及获取临时 code 的链接
        public const string AuthorizationEndpoint = "https://www.douban.com/service/auth2/auth";
        // 获取相关 token 的链接
        public const string TokenEndpoint = "https://www.douban.com/service/auth2/token";
        /// <summary>
        /// 获取 用户基本信息 的链接。
        /// </summary>
        /// PS: 我说怎么有 ~ ，用的用户名来获取单个用户的信息，me 被占用了，想不通为啥对于最开始的用户会用注册名来做 uid，明明有 id 啊。
        /// /v2/user/:name 虽然文档给的用 name 指代，不过从他的返回信息来看，明明用的 uid 或 id，这种感觉很不好。
        /// 从 https://api.douban.com/v2/user/me 这个例子就很容易发现
        public const string UserInformationEndpoint = "https://api.douban.com/v2/user/~me";
    }
}
