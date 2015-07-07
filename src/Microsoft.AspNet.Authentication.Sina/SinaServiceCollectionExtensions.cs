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
        public static IServiceCollection ConfigureSinaAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<SinaAuthenticationOptions> configure, string optionsName = "")
        {
            return services.Configure(configure, optionsName);
        }

        public static IServiceCollection ConfigureSinaAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config, string optionsName = "")
        {
            return services.Configure<SinaAuthenticationOptions>(config, optionsName);
        }
    }
}
