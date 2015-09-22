using Microsoft.AspNet.Authentication.Baidu;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="BaiduMiddleware" />
    /// </summary>
    public static class BaiduAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Baidu.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseBaiduAuthentication([NotNull] this IApplicationBuilder app, Action<BaiduOptions> configureOptions = null)
        {
            return app.UseMiddleware<BaiduMiddleware>(
                 new ConfigureOptions<BaiduOptions>(configureOptions ?? (o => { })));
        }
    }
}
