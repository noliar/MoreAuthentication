using Microsoft.AspNet.Authentication.Youku;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
    /// Extension methods for using <see cref="YoukuAuthenticationMiddleware" />
    /// </summary>
    public static class YoukuServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureYoukuAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<YoukuAuthenticationOptions> configure, string optionsName = "")
        {
            return services.Configure(configure, optionsName);
        }

        public static IServiceCollection ConfigureYoukuAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config, string optionsName = "")
        {
            return services.Configure<YoukuAuthenticationOptions>(config, optionsName);
        }
    }
}
