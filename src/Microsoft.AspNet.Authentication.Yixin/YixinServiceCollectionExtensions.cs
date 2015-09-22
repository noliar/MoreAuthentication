using Microsoft.AspNet.Authentication.Yixin;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
    /// Extension methods for using <see cref="YixinMiddleware" />
    /// </summary>
    public static class YixinServiceCollectionExtensions
    {
        public static IServiceCollection AddYixinAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<YixinOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddYixinAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<YixinOptions>(config);
        }
    }
}
