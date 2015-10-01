using System;
using DevZH.AspNet.Authentication.WeChat;
using Microsoft.Framework.Internal;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="WeChatMiddleware" />
    /// </summary>
    public static class WeChatAppBuilderExtensions
    {
        /// <summary>
		/// Authenticate users using WeChat.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="options">The Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseWeChatAuthentication([NotNull] this IApplicationBuilder app, [NotNull] WeChatOptions options)
        {
            return app.UseMiddleware<WeChatMiddleware>(options);
        }

        /// <summary>
		/// Authenticate users using WeChat.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
		/// <param name="configureOptions">Used to configure Middleware options.</param>
		/// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseWeChatAuthentication([NotNull] this IApplicationBuilder app, Action<WeChatOptions> configureOptions)
        {
            var options = new WeChatOptions();
            configureOptions?.Invoke(options);
            return app.UseWeChatAuthentication(options);
        }
    }
}
