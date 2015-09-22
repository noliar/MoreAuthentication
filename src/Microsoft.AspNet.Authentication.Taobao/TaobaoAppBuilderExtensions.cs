using Microsoft.AspNet.Authentication.Taobao;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;


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
        public static IApplicationBuilder UseTaobaoAuthentication([NotNull] this IApplicationBuilder app, [NotNull] TaobaoOptions options)
        {
            return app.UseMiddleware<TaobaoMiddleware>(options);
        }

        /// <summary>
		/// Authenticate users using Taobao.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="configureOptions">Used to configure Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseTaobaoAuthentication([NotNull] this IApplicationBuilder app, Action<TaobaoOptions> configureOptions)
        {
            var options = new TaobaoOptions();
            configureOptions?.Invoke(options);
            return app.UseTaobaoAuthentication(options);
        }
    }

}
