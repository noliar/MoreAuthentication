using DevZH.AspNet.Authentication.Sina;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="SinaMiddleware" />
    /// </summary>
    public static class SinaAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Sina.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="options">The Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseSinaAuthentication([NotNull] this IApplicationBuilder app, [NotNull] SinaOptions options)
        {
            return app.UseMiddleware<SinaMiddleware>(options);
        }

        /// <summary>
		/// Authenticate users using Sina.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="configureOptions">Used to configure Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseSinaAuthentication([NotNull] this IApplicationBuilder app, Action<SinaOptions> configureOptions)
        {
            var options = new SinaOptions();
            configureOptions?.Invoke(options);
            return app.UseSinaAuthentication(options);
        }
    }
}
