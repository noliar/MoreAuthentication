using Microsoft.AspNet.Authentication.Taobao;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="TaobaoAuthenticationMiddleware" />
	/// </summary>
    public static class TaobaoServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureTaobaoAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<TaobaoAuthenticationOptions> configure, string optionsName = "")
        {
            return services.Configure(configure, optionsName);
        }

        public static IServiceCollection ConfigureTaobaoAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config, string optionsName = "")
        {
            return services.Configure<TaobaoAuthenticationOptions>(config, optionsName);
        }
    }
}
