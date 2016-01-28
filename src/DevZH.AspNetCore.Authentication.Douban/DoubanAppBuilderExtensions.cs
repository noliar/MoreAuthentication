using System;
using DevZH.AspNetCore.Authentication.Douban;

namespace DevZH.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add Douban authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class DoubanAppBuilderExtensions
    {
        /// <summary>
		/// Adds the <see cref="DoubanMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Douban authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <param name="options">A <see cref="DoubanOptions"/> that specifies options for the middleware.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseDoubanAuthentication(this IApplicationBuilder app, DoubanOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<DoubanMiddleware>(options);
        }

        /// <summary>
		/// Adds the <see cref="DoubanMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Douban authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <param name="configureOptions">An action delegate to configure the provided <see cref="DoubanOptions"/>.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseDoubanAuthentication(this IApplicationBuilder app, Action<DoubanOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            var options = new DoubanOptions();
            configureOptions(options);
            return app.UseMiddleware<DoubanMiddleware>(options);
        }
    }
}
