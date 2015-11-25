using System;
using DevZH.AspNet.Authentication.WeChat;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods to add WeChat authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class WeChatAppBuilderExtensions
    {
        /// <summary>
		/// Adds the <see cref="WeChatMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables WeChat authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <param name="options">A <see cref="WeChatOptions"/> that specifies options for the middleware.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseWeChatAuthentication(this IApplicationBuilder app, WeChatOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<WeChatMiddleware>(options);
        }

        /// <summary>
		/// Adds the <see cref="WeChatMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables WeChat authentication capabilities.
		/// </summary>
		/// <param name="app">The <see cref="IApplicationBuilder" /> to add the middleware to.</param>
		/// <param name="configureOptions">An action delegate to configure the provided <see cref="WeChatOptions"/>.</param>
		/// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseWeChatAuthentication(this IApplicationBuilder app, Action<WeChatOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new WeChatOptions();
            configureOptions?.Invoke(options);
            return app.UseWeChatAuthentication(options);
        }
    }
}
