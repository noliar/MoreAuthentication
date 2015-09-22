using Microsoft.AspNet.Authentication.WeChat;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Internal;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    /// <summary>
	/// Extension methods for using <see cref="WeChatMiddleware" />
	/// </summary>
    public static class WeChatServiceCollectionExtensions
    {
        public static IServiceCollection AddWeChatAuthentication([NotNull] this IServiceCollection services, [NotNull] Action<WeChatOptions> configure)
        {
            return services.Configure(configure);
        }

        public static IServiceCollection AddWeChatAuthentication([NotNull] this IServiceCollection services, [NotNull] IConfiguration config)
        {
            return services.Configure<WeChatOptions>(config);
        }
    }
}
