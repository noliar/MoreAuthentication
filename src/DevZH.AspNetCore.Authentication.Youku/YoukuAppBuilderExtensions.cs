using System;
using DevZH.AspNetCore.Authentication.Youku;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace DevZH.AspNetCore.Builder
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

            return app.UseMiddleware<YoukuMiddleware>(Options.Create(options));
        }

        /// <summary>
        /// Adds the <see cref="YoukuMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Youku authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseYoukuAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            
            return app.UseMiddleware<YoukuMiddleware>();
        }
    }
}
