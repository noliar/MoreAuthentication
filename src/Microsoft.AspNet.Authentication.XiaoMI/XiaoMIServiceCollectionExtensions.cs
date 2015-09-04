using Microsoft.AspNet.Authentication.XiaoMI;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="XiaoMIAuthenticationMiddleware" />
	/// </summary>
    public static class XiaoMIServiceCollectionExtensions
    {
        public static IServiceCollection AddXiaoMIAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<XiaoMIAuthenticationOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddXiaoMIAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<XiaoMIAuthenticationOptions>(config);
        }
    }
}
