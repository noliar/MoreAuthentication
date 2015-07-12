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
        public static IServiceCollection ConfigureWeixinAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<WeixinAuthenticationOptions> configure, string optionsName = "")
        {
            return services.Configure(configure, optionsName);
        }

        public static IServiceCollection ConfigureWeixinAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config, string optionsName = "")
        {
            return services.Configure<WeixinAuthenticationOptions>(config, optionsName);
        }
    }
}
