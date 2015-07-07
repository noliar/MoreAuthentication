using Microsoft.AspNet.Authentication.Douban;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="DoubanAuthenticationMiddleware" />
	/// </summary>
    public static class DoubanServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDoubanAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<DoubanAuthenticationOptions> configure, string optionsName = "")
        {
            return services.Configure(configure, optionsName);
        }

        public static IServiceCollection ConfigureDoubanAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config, string optionsName = "")
        {
            return services.Configure<DoubanAuthenticationOptions>(config, optionsName);
        }
    }
}
