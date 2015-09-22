using Microsoft.AspNet.Authentication.XiaoMi;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="XiaoMiMiddleware" />
    /// </summary>
    public static class XiaoMiAppBuilderExtensions
    {
        /// <summary>
        /// Authenticate users using Xiao Mi.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
        /// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseXiaoMiAuthentication([NotNull] this IApplicationBuilder app, Action<XiaoMiOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<XiaoMiMiddleware>(
                 new ConfigureOptions<XiaoMiOptions>(configureOptions ?? (o => { })));
        }
    }
}
