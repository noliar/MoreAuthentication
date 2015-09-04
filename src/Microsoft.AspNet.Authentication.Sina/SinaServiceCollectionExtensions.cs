using Microsoft.AspNet.Authentication.Sina;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="SinaAuthenticationMiddleware" />
	/// </summary>
    public static class SinaServiceCollectionExtensions
    {
        public static IServiceCollection AddSinaAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<SinaAuthenticationOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddSinaAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<SinaAuthenticationOptions>(config);
        }
    }
}
