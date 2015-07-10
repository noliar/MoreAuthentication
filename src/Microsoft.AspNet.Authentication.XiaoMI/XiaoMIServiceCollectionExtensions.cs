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
        public static IServiceCollection ConfigureXiaoMIAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<XiaoMIAuthenticationOptions> configure, string optionsName = "")
        {
            return services.Configure(configure, optionsName);
        }

        public static IServiceCollection ConfigureXiaoMIAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config, string optionsName = "")
        {
            return services.Configure<XiaoMIAuthenticationOptions>(config, optionsName);
        }
    }
}
