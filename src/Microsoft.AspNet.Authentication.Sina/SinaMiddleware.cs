using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;
using System;

namespace Microsoft.AspNet.Authentication.Sina
{
    /// <summary>
	/// An ASP.NET middleware for authenticating users using Sina.
	/// </summary>
    public class SinaMiddleware : OAuthMiddleware<SinaOptions>
    {
        /// <summary>
		/// Initializes a new <see cref="SinaMiddleware" />.
		/// </summary>
		/// <param name="next">The next middleware in the application pipeline to invoke.</param>
		/// <param name="options">Configuration options for the middleware.</param>
        public SinaMiddleware(
           [NotNull] RequestDelegate next,
           [NotNull] IDataProtectionProvider dataProtectionProvider,
           [NotNull] ILoggerFactory loggerFactory,
           [NotNull] IUrlEncoder encoder,
           [NotNull] IOptions<SharedAuthenticationOptions> sharedOptions,
           [NotNull] IOptions<SinaOptions> options,
           ConfigureOptions<SinaOptions> configureOptions = null) 
            : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options, configureOptions)
        {
            if (string.IsNullOrWhiteSpace(Options.AppKey))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppKey)} 值非法");
            }
            if (string.IsNullOrWhiteSpace(Options.AppSecret))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppSecret)} 值非法");
            }
        }

        /// <summary>
		/// Provides the <see cref="AuthenticationHandler" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler" /> configured with the <see cref="SinaOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<SinaOptions> CreateHandler()
        {
            return new SinaHandler(Backchannel);
        }
    }
}
