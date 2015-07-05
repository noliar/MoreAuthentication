using Microsoft.AspNet.Authentication.Baidu;
using Microsoft.Framework.Internal;
using Microsoft.Framework.OptionsModel;
using System;

namespace Microsoft.AspNet.Builder
{
    /// <summary>
    /// Extension methods for using <see cref="BaiduAuthenticationMiddleware" />
    /// </summary>
    public static class BaiduAppBuilderExtensions
    {
        public static IApplicationBuilder UseBaiduAuthentication([NotNull] this IApplicationBuilder app, Action<BaiduAuthenticationOptions> configureOptions = null, string optionsName = "")
        {
            return app.UseMiddleware<BaiduAuthenticationMiddleware>(
                 new ConfigureOptions<BaiduAuthenticationOptions>(configureOptions ?? (o => { }))
                 {
                     Name = optionsName
                 });
        }
    }
}
