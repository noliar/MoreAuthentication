using System;
using DevZH.AspNet.Authentication.NetEase;
using Microsoft.Framework.Internal;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="NetEaseMiddleware" />
    /// </summary>
    public static class NetEaseAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using NetEase.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="options">The Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseNetEaseAuthentication([NotNull] this IApplicationBuilder app, [NotNull] NetEaseOptions options)
        {
            return app.UseMiddleware<NetEaseMiddleware>(options);
        }

        /// <summary>
        /// Authenticate users using NetEase.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> passed to the configure method.</param>
        /// <param name="configureOptions">Configures the options.</param>
        /// <returns>The updated <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder UseNetEaseAuthentication([NotNull] this IApplicationBuilder app, Action<NetEaseOptions> configureOptions)
        {
            var options = new NetEaseOptions();
            configureOptions?.Invoke(options);
            return app.UseNetEaseAuthentication(options);
        }
    }
}
