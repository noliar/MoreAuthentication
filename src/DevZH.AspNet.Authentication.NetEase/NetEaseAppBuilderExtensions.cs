using System;
using DevZH.AspNet.Authentication.NetEase;

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
        public static IApplicationBuilder UseNetEaseAuthentication(this IApplicationBuilder app, NetEaseOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<NetEaseMiddleware>(options);
        }

        /// <summary>
        /// Authenticate users using NetEase.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> passed to the configure method.</param>
        /// <param name="configureOptions">Configures the options.</param>
        /// <returns>The updated <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder UseNetEaseAuthentication(this IApplicationBuilder app, Action<NetEaseOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new NetEaseOptions();
            configureOptions?.Invoke(options);
            return app.UseNetEaseAuthentication(options);
        }
    }
}
