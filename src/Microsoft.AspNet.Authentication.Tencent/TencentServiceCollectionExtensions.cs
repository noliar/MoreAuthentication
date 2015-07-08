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
        public static IServiceCollection ConfigureTencentAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<TencentAuthenticationOptions> configure, string optionsName = "")
        {
            return services.Configure(configure, optionsName);
        }

        public static IServiceCollection ConfigureTencentAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config, string optionsName = "")
        {
            return services.Configure<TencentAuthenticationOptions>(config, optionsName);
        }
    }
}
