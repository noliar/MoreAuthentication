using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;

namespace Microsoft.AspNet.Authentication.Baidu
{
    public class BaiduAuthenticationMiddleware : OAuthAuthenticationMiddleware<BaiduAuthenticationOptions>
    {
        public BaiduAuthenticationMiddleware(
            [NotNull] RequestDelegate next,
            [NotNull] IDataProtectionProvider dataProtectionProvider,
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] IUrlEncoder encoder,
            [NotNull] IOptions<ExternalAuthenticationOptions> externalOptions,
            [NotNull] IOptions<BaiduAuthenticationOptions> options,
            ConfigureOptions<BaiduAuthenticationOptions> configureOptions = null) 
            : base(next, dataProtectionProvider, loggerFactory, encoder, externalOptions, options, configureOptions)
        {
            if (Options.Scope.Count == 0)
            {
                Options.Scope.Add("basic");
            }
        }

        protected override AuthenticationHandler<BaiduAuthenticationOptions> CreateHandler()
        {
            return new BaiduAuthenticationHandler(Backchannel);
        }
    }
}