using System;
using DevZH.AspNet.Authentication.Qihoo;
using Microsoft.Framework.Internal;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="QihooMiddleware" />
    /// </summary>
    public static class QihooAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Qihoo 360.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="options">The Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseQihooAuthentication([NotNull] this IApplicationBuilder app, [NotNull] QihooOptions options)
        {
            return app.UseMiddleware<QihooMiddleware>(options);
        }

        /// <summary>
        /// Authenticate users using Qihoo 360.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> passed to the configure method.</param>
        /// <param name="configureOptions">Configures the options.</param>
        /// <returns>The updated <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder UseQihooAuthentication([NotNull] this IApplicationBuilder app, Action<QihooOptions> configureOptions)
        {
            var options = new QihooOptions();
            configureOptions?.Invoke(options);
            return app.UseQihooAuthentication(options);
        }
    }
}
