using Microsoft.AspNet.Authentication.Baidu;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="BaiduAuthenticationMiddleware" />
	/// </summary>
    public static class BaiduServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureBaiduAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<BaiduAuthenticationOptions> configure, string optionsName = "")
        {
            return services.Configure(configure, optionsName);
        }

        public static IServiceCollection ConfigureBaiduAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config, string optionsName = "")
        {
            return services.Configure<BaiduAuthenticationOptions>(config, optionsName);
        }
    }
}
