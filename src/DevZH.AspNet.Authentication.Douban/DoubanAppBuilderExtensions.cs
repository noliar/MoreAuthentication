using System;
using DevZH.AspNet.Authentication.Douban;
using Microsoft.Extensions.Internal;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="DoubanMiddleware" />
    /// </summary>
    public static class DoubanAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Douban.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="options">The Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseDoubanAuthentication([NotNull] this IApplicationBuilder app, [NotNull] DoubanOptions options)
        {
            return app.UseMiddleware<DoubanMiddleware>(options);
        }

        /// <summary>
		/// Authenticate users using Douban.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="configureOptions">Used to configure Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseDoubanAuthentication([NotNull] this IApplicationBuilder app, Action<DoubanOptions> configureOptions)
        {
            var options = new DoubanOptions();
            configureOptions?.Invoke(options);
            return app.UseDoubanAuthentication(options);
        }
    }
}
