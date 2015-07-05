using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;

namespace Microsoft.AspNet.Authentication.Baidu
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using the Baidu Account service.
    /// </summary>
    public class BaiduAuthenticationMiddleware : OAuthAuthenticationMiddleware<BaiduAuthenticationOptions>
    {
        /// <summary>
        ///  构造一个新的 <see cref="BaiduAuthenticationMiddleware"/>
        /// </summary>
        /// <param name="next">The next middleware in the HTTP pipeline to invoke.</param>
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

        /// <summary>
        /// Provides the <see cref="AuthenticationHandler"/> object for processing authentication-related requests.
        /// </summary>
        /// <returns>An <see cref="AuthenticationHandler"/> configured with the <see cref="BaiduAuthenticationHandler"/> supplied to the constructor.</returns>
        protected override AuthenticationHandler<BaiduAuthenticationOptions> CreateHandler()
        {
            return new BaiduAuthenticationHandler(Backchannel);
        }
    }
}