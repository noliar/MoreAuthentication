using Microsoft.AspNet.Authentication.Tencent;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="TencentAuthenticationMiddleware" />
	/// </summary>
    public static class TencentServiceCollectionExtensions
    {
        public static IServiceCollection AddTencentAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<TencentAuthenticationOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddTencentAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<TencentAuthenticationOptions>(config);
        }
    }
}
