using System;
using DevZH.AspNet.Authentication.Qihoo;

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
        public static IApplicationBuilder UseQihooAuthentication(this IApplicationBuilder app, QihooOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<QihooMiddleware>(options);
        }

        /// <summary>
        /// Authenticate users using Qihoo 360.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> passed to the configure method.</param>
        /// <param name="configureOptions">Configures the options.</param>
        /// <returns>The updated <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder UseQihooAuthentication(this IApplicationBuilder app, Action<QihooOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new QihooOptions();
            configureOptions?.Invoke(options);
            return app.UseQihooAuthentication(options);
        }
    }
}
