using Microsoft.AspNet.Authentication.XiaoMi;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="XiaoMiMiddleware" />
	/// </summary>
    public static class XiaoMiServiceCollectionExtensionss
    {
        public static IServiceCollection AddXiaoMiAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<XiaoMiOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddXiaoMiAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<XiaoMiOptions>(config);
        }
    }
}
