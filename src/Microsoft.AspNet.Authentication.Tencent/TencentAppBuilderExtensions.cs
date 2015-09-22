using Microsoft.AspNet.Authentication.Tencent;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

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
        public static IApplicationBuilder UseTencentAuthentication([NotNull] this IApplicationBuilder app, [NotNull] TencentOptions options)
        {
            return app.UseMiddleware<TencentMiddleware>(options);
        }

        /// <summary>
		/// Authenticate users using Tencent.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="configureOptions">Used to configure Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseTencentAuthentication([NotNull] this IApplicationBuilder app, Action<TencentOptions> configureOptions)
        {
            var options = new TencentOptions();
            configureOptions?.Invoke(options);
            return app.UseTencentAuthentication(options);
        }
    }
}
