using Microsoft.AspNet.Authentication.Youku;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
    /// Extension methods for using <see cref="YoukuMiddleware" />
    /// </summary>
    public static class YoukuServiceCollectionExtensions
    {
        public static IServiceCollection AddYoukuAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<YoukuOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddYoukuAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<YoukuOptions>(config);
        }
    }
}
