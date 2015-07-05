using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.AspNet.Authentication.Baidu
{
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
