using Microsoft.AspNet.Authentication.Yixin;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
    /// Extension methods for using <see cref="YixinServiceCollectionExtensions" />
    /// </summary>
    public static class YixinServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureYixinAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<YixinAuthenticationOptions> configure, string optionsName = "")
        {
            return services.Configure(configure, optionsName);
        }

        public static IServiceCollection ConfigureYixinAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config, string optionsName = "")
        {
            return services.Configure<YixinAuthenticationOptions>(config, optionsName);
        }
    }
}
