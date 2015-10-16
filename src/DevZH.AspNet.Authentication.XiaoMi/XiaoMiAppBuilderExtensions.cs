using System;
using DevZH.AspNet.Authentication.XiaoMi;

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
        /// <param name="options">The Middleware options.</param>
        /// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseXiaoMiAuthentication(this IApplicationBuilder app, XiaoMiOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<XiaoMiMiddleware>(options);
        }

        /// <summary>
        /// Authenticate users using Xiao Mi.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
        /// <param name="configureOptions">Used to configure Middleware options.</param>
        /// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseXiaoMiAuthentication(this IApplicationBuilder app, Action<XiaoMiOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new XiaoMiOptions();
            configureOptions?.Invoke(options);
            return app.UseXiaoMiAuthentication(options);
        }
    }
}
