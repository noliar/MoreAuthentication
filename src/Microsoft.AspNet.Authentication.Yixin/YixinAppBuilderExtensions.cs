using Microsoft.AspNet.Authentication.Yixin;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

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
        public static IApplicationBuilder UseYixinAuthentication([NotNull] this IApplicationBuilder app, [NotNull] YixinOptions options)
        {
            return app.UseMiddleware<YixinMiddleware>(options);
        }

        /// <summary>
		/// Authenticate users using Yixin.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="configureOptions">Used to configure Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseYixinAuthentication([NotNull] this IApplicationBuilder app, Action<YixinOptions> configureOptions)
        {
            var options = new YixinOptions();
            configureOptions?.Invoke(options);
            return app.UseYixinAuthentication(options);
        }
    }
}
