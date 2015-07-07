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
    internal static class SinaAuthenticationExtensions
    {
        internal static string GetDescription([NotNull] this SinaAuthenticationOptions.DisplayStyle style) => style.ToString().ToLower();
    }
}
