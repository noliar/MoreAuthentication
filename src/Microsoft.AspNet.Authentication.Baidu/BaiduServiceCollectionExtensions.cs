using Microsoft.AspNet.Authentication.Baidu;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="BaiduMiddleware" />
	/// </summary>
    public static class BaiduServiceCollectionExtensions
    {
        public static IServiceCollection AddBaiduAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<BaiduOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddBaiduAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<BaiduOptions>(config);
        }
    }
}
