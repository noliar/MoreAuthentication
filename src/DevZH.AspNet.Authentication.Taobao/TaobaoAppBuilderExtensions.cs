using System;
using DevZH.AspNet.Authentication.Taobao;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="TaobaoMiddleware" />
    /// </summary>
    public static class TaobaoAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Taobao.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="options">The Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
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

            return app.UseMiddleware<TaobaoMiddleware>(options);
        }

        /// <summary>
		/// Authenticate users using Taobao.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="configureOptions">Used to configure Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseTaobaoAuthentication(this IApplicationBuilder app, Action<TaobaoOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new TaobaoOptions();
            configureOptions?.Invoke(options);
            return app.UseTaobaoAuthentication(options);
        }
    }

}
