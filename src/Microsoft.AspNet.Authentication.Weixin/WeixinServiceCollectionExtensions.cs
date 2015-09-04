using Microsoft.AspNet.Authentication.Weixin;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="WeixinAuthenticationMiddleware" />
	/// </summary>
    public static class WeixinServiceCollectionExtensions
    {
        public static IServiceCollection AddWeixinAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<WeixinAuthenticationOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddWeixinAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<WeixinAuthenticationOptions>(config);
        }
    }
}
