using Microsoft.AspNet.Authentication.Taobao;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;


namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="TaobaoAuthenticationMiddleware" />
    /// </summary>
    public static class TaobaoAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Taobao.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseTaobaoAuthentication([NotNull] this IApplicationBuilder app, Action<TaobaoAuthenticationOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<TaobaoAuthenticationMiddleware>(
                 new ConfigureOptions<TaobaoAuthenticationOptions>(configureOptions ?? (o => { }))
                 {
                     Name = optionsName
                 });
        }
    }

}
