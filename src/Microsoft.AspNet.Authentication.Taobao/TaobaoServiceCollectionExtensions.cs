using Microsoft.AspNet.Authentication.Taobao;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="TaobaoMiddleware" />
	/// </summary>
    public static class TaobaoServiceCollectionExtensions
    {
        public static IServiceCollection AddTaobaoAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<TaobaoOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddTaobaoAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<TaobaoOptions>(config);
        }
    }
}
