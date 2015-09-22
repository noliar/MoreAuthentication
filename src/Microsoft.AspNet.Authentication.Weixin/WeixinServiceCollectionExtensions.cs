using Microsoft.AspNet.Authentication.Weixin;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="WeixinMiddleware" />
	/// </summary>
    public static class WeixinServiceCollectionExtensions
    {
        public static IServiceCollection AddWeixinAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<WeixinOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddWeixinAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<WeixinOptions>(config);
        }
    }
}
