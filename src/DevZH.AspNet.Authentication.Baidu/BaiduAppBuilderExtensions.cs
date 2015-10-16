using DevZH.AspNet.Authentication.Baidu;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="BaiduMiddleware" />
    /// </summary>
    public static class BaiduAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Baidu.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="options">The Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseBaiduAuthentication(this IApplicationBuilder app, BaiduOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<BaiduMiddleware>(options);
        }

        /// <summary>
        /// Authenticate users using Baidu.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> passed to the configure method.</param>
        /// <param name="configureOptions">Configures the options.</param>
        /// <returns>The updated <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder UseBaiduAuthentication(this IApplicationBuilder app, Action<BaiduOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new BaiduOptions();
            configureOptions?.Invoke(options);
            return app.UseBaiduAuthentication(options);
        }
    }
}
