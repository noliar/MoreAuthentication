using Microsoft.AspNet.Authentication.Tencent;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="TencentMiddleware" />
    /// </summary>
    public static class TencentAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Baidu.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseTencentAuthentication([NotNull] this IApplicationBuilder app, Action<TencentOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<TencentMiddleware>(
                 new ConfigureOptions<TencentOptions>(configureOptions ?? (o => { })));
        }
    }
}
