using System;
using DevZH.AspNet.Authentication.Tencent;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="TencentMiddleware" />
    /// </summary>
    public static class TencentAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Tencent.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="options">The Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseTencentAuthentication(this IApplicationBuilder app, TencentOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<TencentMiddleware>(options);
        }

        /// <summary>
		/// Authenticate users using Tencent.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="configureOptions">Used to configure Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseTencentAuthentication(this IApplicationBuilder app, Action<TencentOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new TencentOptions();
            configureOptions?.Invoke(options);
            return app.UseTencentAuthentication(options);
        }
    }
}
