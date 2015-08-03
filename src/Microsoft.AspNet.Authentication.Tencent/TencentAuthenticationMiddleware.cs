using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;
using System;

namespace Microsoft.AspNet.Authentication.Tencent
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using the Tencent QQ Account service.
    /// </summary>
    public class TencentAuthenticationMiddleware : OAuthAuthenticationMiddleware<TencentAuthenticationOptions>
    {
        /// <summary>
		/// Initializes a new <see cref="TencentAuthenticationMiddleware" />.
		/// </summary>
		/// <param name="next">The next middleware in the application pipeline to invoke.</param>
		/// <param name="options">Configuration options for the middleware.</param>
        public TencentAuthenticationMiddleware(
           [NotNull] RequestDelegate next,
           [NotNull] IDataProtectionProvider dataProtectionProvider,
           [NotNull] ILoggerFactory loggerFactory,
           [NotNull] IUrlEncoder encoder,
           [NotNull] IOptions<SharedAuthenticationOptions> sharedOptions,
           [NotNull] IOptions<TencentAuthenticationOptions> options,
           ConfigureOptions<TencentAuthenticationOptions> configureOptions = null)
            : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options, configureOptions)
        {
            if (string.IsNullOrWhiteSpace(Options.AppId))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppId)} 值非法");
            }
            if (string.IsNullOrWhiteSpace(Options.AppKey))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppKey)} 值非法");
            }
            if (Options.Scope.Count == 0)
            {
                Options.Scope.Add("get_user_info");
            }
        }

        /// <summary>
		/// Provides the <see cref="AuthenticationHandler" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler" /> configured with the <see cref="TencentAuthenticationOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<TencentAuthenticationOptions> CreateHandler()
        {
            return new TencentAuthenticationHandler(Backchannel);
        }
    }
}
