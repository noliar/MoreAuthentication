using System;
using DevZH.AspNet.Authentication.Youku;
using Microsoft.Extensions.Internal;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="YoukuMiddleware" />
    /// </summary>
    public static class YoukuAppBuilderExtensions
    {
        /// <summary>
        /// Authenticate users using Youku.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
        /// <param name="options">The Middleware options.</param>
        /// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseYoukuAuthentication([NotNull] this IApplicationBuilder app, [NotNull] YoukuOptions options)
        {
            return app.UseMiddleware<YoukuMiddleware>(options);
        }

        /// <summary>
        /// Authenticate users using Youku.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder" /> passed to the configure method.</param>
        /// <param name="configureOptions">Used to configure Middleware options.</param>
        /// <returns>The updated <see cref="IApplicationBuilder" />.</returns>
        public static IApplicationBuilder UseYoukuAuthentication([NotNull] this IApplicationBuilder app, Action<YoukuOptions> configureOptions)
        {
            var options = new YoukuOptions();
            configureOptions?.Invoke(options);
            return app.UseYoukuAuthentication(options);
        }
    }
}
