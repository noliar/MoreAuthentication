using Microsoft.AspNet.Authentication.WeChat;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="WeChatMiddleware" />
    /// </summary>
    public static class WeChatAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using Weixin.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseWeChatAuthentication([NotNull] this IApplicationBuilder app, Action<WeChatOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<WeChatMiddleware>(
                 new ConfigureOptions<WeChatOptions>(configureOptions ?? (o => { })));
        }
    }
}
