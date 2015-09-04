using Microsoft.AspNet.Authentication.Yixin;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
    /// Extension methods for using <see cref="YixinAuthenticationMiddleware" />
    /// </summary>
    public static class YixinServiceCollectionExtensions
    {
        public static IServiceCollection AddYixinAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<YixinAuthenticationOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddYixinAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<YixinAuthenticationOptions>(config);
        }
    }
}
