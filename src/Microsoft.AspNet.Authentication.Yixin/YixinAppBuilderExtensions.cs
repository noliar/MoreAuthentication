using Microsoft.AspNet.Authentication.Yixin;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="YixinMiddleware" />
    /// </summary>
    public static class YixinAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Yixin.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseYixinAuthentication([NotNull] this IApplicationBuilder app, Action<YixinOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<YixinMiddleware>(
                 new ConfigureOptions<YixinOptions>(configureOptions ?? (o => { })));
        }
    }
}
