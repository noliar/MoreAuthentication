using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;
using System;

namespace Microsoft.AspNet.Authentication.Taobao
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using Taobao.
    /// </summary>
    public class TaobaoAuthenticationMiddleware : OAuthAuthenticationMiddleware<TaobaoAuthenticationOptions>
    {
        /// <summary>
        /// Initializes a new <see cref="TaobaoAuthenticationMiddleware" />.
        /// </summary>
        /// <param name="next">The next middleware in the application pipeline to invoke.</param>
        /// <param name="options">Configuration options for the middleware.</param>
        public TaobaoAuthenticationMiddleware(
           [NotNull] RequestDelegate next,
           [NotNull] IDataProtectionProvider dataProtectionProvider,
           [NotNull] ILoggerFactory loggerFactory,
           [NotNull] IUrlEncoder encoder,
           [NotNull] IOptions<ExternalAuthenticationOptions> externalOptions,
           [NotNull] IOptions<TaobaoAuthenticationOptions> options,
           ConfigureOptions<TaobaoAuthenticationOptions> configureOptions = null) 
            : base(next, dataProtectionProvider, loggerFactory, encoder, externalOptions, options, configureOptions)
        {
        }

        /// <summary>
		/// Provides the <see cref="AuthenticationHandler" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler" /> configured with the <see cref="TaobaoAuthenticationOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<TaobaoAuthenticationOptions> CreateHandler()
        {
            return new TaobaoAuthenticationHandler(Backchannel);
        }

    }
}
