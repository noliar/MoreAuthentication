using Microsoft.AspNet.Authentication.Douban;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="DoubanMiddleware" />
    /// </summary>
    public static class DoubanAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Douban.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseDoubanAuthentication([NotNull] this IApplicationBuilder app, Action<DoubanOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<DoubanMiddleware>(
                 new ConfigureOptions<DoubanOptions>(configureOptions ?? (o => { })));
        }
    }
}
