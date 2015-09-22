using Microsoft.AspNet.Authentication.Douban;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="DoubanMiddleware" />
	/// </summary>
    public static class DoubanServiceCollectionExtensions
    {
        public static IServiceCollection AddDoubanAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<DoubanOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddDoubanAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<DoubanOptions>(config);
        }
    }
}
