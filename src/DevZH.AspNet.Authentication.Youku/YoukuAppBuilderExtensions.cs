using System;
using DevZH.AspNet.Authentication.Youku;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="YoukuMiddleware" />
    /// </summary>
    public static class YoukuAppBuilderExtensions
    {
        /// <summary>
        /// Authenticate users using Youku.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
        /// <param name="options">The Middleware options.</param>
        /// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseYoukuAuthentication(this IApplicationBuilder app, YoukuOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<YoukuMiddleware>(options);
        }

        /// <summary>
        /// Authenticate users using Youku.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
        /// <param name="configureOptions">Used to configure Middleware options.</param>
        /// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseYoukuAuthentication(this IApplicationBuilder app, Action<YoukuOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            
            var options = new YoukuOptions();
            configureOptions?.Invoke(options);
            return app.UseYoukuAuthentication(options);
        }
    }
}
