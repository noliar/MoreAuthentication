using System;
using DevZH.AspNet.Authentication.Yixin;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="YixinMiddleware" />
    /// </summary>
    public static class YixinAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Yixin.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="options">The Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseYixinAuthentication(this IApplicationBuilder app, YixinOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<YixinMiddleware>(options);
        }

        /// <summary>
		/// Authenticate users using Yixin.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="configureOptions">Used to configure Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseYixinAuthentication(this IApplicationBuilder app, Action<YixinOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new YixinOptions();
            configureOptions?.Invoke(options);
            return app.UseYixinAuthentication(options);
        }
    }
}
