using Microsoft.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Sina
{
    /// <summary>
    ///  扩展类
    /// </summary>
    public static class SinaAuthenticationExtensions
    {
        public static string GetDescription([NotNull] this SinaAuthenticationOptions.DisplayStyle style) => style.ToString().ToLower();
    }
}
