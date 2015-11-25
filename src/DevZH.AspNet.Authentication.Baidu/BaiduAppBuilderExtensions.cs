using DevZH.AspNet.Authentication.Baidu;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods to add Baidu authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class BaiduAppBuilderExtensions
    {
        /// <summary>
		/// Adds the <see cref="BaiduMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Baidu authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <param name="options">A <see cref="BaiduOptions"/> that specifies options for the middleware.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseBaiduAuthentication(this IApplicationBuilder app, BaiduOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<BaiduMiddleware>(options);
        }

        /// <summary>
        /// Adds the <see cref="BaiduMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Baidu authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="configureOptions">An action delegate to configure the provided <see cref="BaiduOptions"/>.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseBaiduAuthentication(this IApplicationBuilder app, Action<BaiduOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new BaiduOptions();
            configureOptions?.Invoke(options);
            return app.UseBaiduAuthentication(options);
        }
    }
}
