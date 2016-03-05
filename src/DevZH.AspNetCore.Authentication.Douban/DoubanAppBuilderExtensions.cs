using System;
using DevZH.AspNetCore.Authentication.Douban;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

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

            return app.UseMiddleware<DoubanMiddleware>(Options.Create(options));
        }

        /// <summary>
		/// Adds the <see cref="DoubanMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Douban authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseDoubanAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<DoubanMiddleware>();
        }
    }
}
