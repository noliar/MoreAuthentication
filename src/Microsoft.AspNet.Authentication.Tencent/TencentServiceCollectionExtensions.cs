using Microsoft.AspNet.Authentication.Tencent;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="TencentMiddleware" />
	/// </summary>
    public static class TencentServiceCollectionExtensions
    {
        public static IServiceCollection AddTencentAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<TencentOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddTencentAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<TencentOptions>(config);
        }
    }
}
