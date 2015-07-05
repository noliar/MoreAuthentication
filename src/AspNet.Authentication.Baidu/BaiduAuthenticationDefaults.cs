using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Baidu
{
    public static class BaiduAuthenticationDefaults
    {
        public const string AuthenticationScheme = "Baidu";

        public const string AuthorizationEndpoint = "https://openapi.baidu.com/oauth/2.0/authorize";

        public const string TokenEndpoint = "https://openapi.baidu.com/oauth/2.0/token";

        // public const string UserInformationEndpoint = "https://openapi.baidu.com/rest/2.0/passport/users/getInfo";
        public const string UserInformationEndpoint = "https://openapi.baidu.com/rest/2.0/passport/users/getLoggedInUser";
    }
}
