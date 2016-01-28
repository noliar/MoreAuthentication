using System;
using DevZH.AspNet.Authentication.Youku;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods to add Youku authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class YoukuAppBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="YoukuMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Youku authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
        /// <param name="options">A <see cref="YoukuOptions"/> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
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
        /// Adds the <see cref="YoukuMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Youku authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
        /// <param name="configureOptions">An action delegate to configure the provided <see cref="YoukuOptions"/>.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseYoukuAuthentication(this IApplicationBuilder app, Action<YoukuOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            var options = new YoukuOptions();
            configureOptions(options);
            return app.UseMiddleware<YoukuMiddleware>(options);
        }
    }
}
