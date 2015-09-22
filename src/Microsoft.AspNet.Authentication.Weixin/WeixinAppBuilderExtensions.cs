using Microsoft.AspNet.Authentication.Weixin;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="WeixinMiddleware" />
    /// </summary>
    public static class WeixinAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Weixin.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseWeixinAuthentication([NotNull] this IApplicationBuilder app, Action<WeixinOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<WeixinMiddleware>(
                 new ConfigureOptions<WeixinOptions>(configureOptions ?? (o => { })));
        }
    }
}
