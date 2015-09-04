using Microsoft.AspNet.Authentication.Sina;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="SinaAuthenticationMiddleware" />
    /// </summary>
    public static class SinaAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Sina.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseSinaAuthentication([NotNull] this IApplicationBuilder app, Action<SinaAuthenticationOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<SinaAuthenticationMiddleware>(
                 new ConfigureOptions<SinaAuthenticationOptions>(configureOptions ?? (o => { })));
        }
    }
}
