using System;
using DevZH.AspNetCore.Authentication.Taobao;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace DevZH.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add Taobao authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class TaobaoAppBuilderExtensions
    {
        /// <summary>
		/// Adds the <see cref="TaobaoMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Taobao authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <param name="options">A <see cref="BaiduOptions"/> that specifies options for the middleware.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseTaobaoAuthentication(this IApplicationBuilder app, TaobaoOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<TaobaoMiddleware>(Options.Create(options));
        }

        /// <summary>
		/// Adds the <see cref="TaobaoMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables Taobao authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseTaobaoAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            
            return app.UseMiddleware<TaobaoMiddleware>();
        }
    }

}
