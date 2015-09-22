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
    public class TaobaoMiddleware : OAuthMiddleware<TaobaoOptions>
    {
        /// <summary>
        /// Initializes a new <see cref="TaobaoMiddleware" />.
        /// </summary>
        /// <param name="next">The next middleware in the application pipeline to invoke.</param>
        /// <param name="options">Configuration options for the middleware.</param>
        public TaobaoMiddleware(
           [NotNull] RequestDelegate next,
           [NotNull] IDataProtectionProvider dataProtectionProvider,
           [NotNull] ILoggerFactory loggerFactory,
           [NotNull] IUrlEncoder encoder,
           [NotNull] IOptions<SharedAuthenticationOptions> sharedOptions,
           [NotNull] IOptions<TaobaoOptions> options,
           ConfigureOptions<TaobaoOptions> configureOptions = null) 
            : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options, configureOptions)
        {
        }

        /// <summary>
		/// Provides the <see cref="AuthenticationHandler" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler" /> configured with the <see cref="TaobaoOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<TaobaoOptions> CreateHandler()
        {
            return new TaobaoHandler(Backchannel);
        }

    }
}
