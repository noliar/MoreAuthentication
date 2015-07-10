using Microsoft.AspNet.Authentication.XiaoMI;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="XiaoMIAuthenticationMiddleware" />
    /// </summary>
    public static class XiaoMIAppBuilderExtensions
    {
        /// <summary>
        /// Authenticate users using Xiao MI.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
        /// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseXiaoMIAuthentication([NotNull] this IApplicationBuilder app, Action<XiaoMIAuthenticationOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<XiaoMIAuthenticationMiddleware>(
                 new ConfigureOptions<XiaoMIAuthenticationOptions>(configureOptions ?? (o => { }))
                 {
                     Name = optionsName
                 });
        }
    }
}
