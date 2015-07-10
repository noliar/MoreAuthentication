using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;

namespace Microsoft.AspNet.Authentication.Youku
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using Youku.
    /// </summary>
    public class YoukuAuthenticationMiddleware : OAuthAuthenticationMiddleware<YoukuAuthenticationOptions>
    {
        /// <summary>
		/// Initializes a new <see cref="YoukuAuthenticationMiddleware" />.
		/// </summary>
		/// <param name="next">The next middleware in the application pipeline to invoke.</param>
		/// <param name="options">Configuration options for the middleware.</param>
        public YoukuAuthenticationMiddleware(
           [NotNull] RequestDelegate next,
           [NotNull] IDataProtectionProvider dataProtectionProvider,
           [NotNull] ILoggerFactory loggerFactory,
           [NotNull] IUrlEncoder encoder,
           [NotNull] IOptions<ExternalAuthenticationOptions> externalOptions,
           [NotNull] IOptions<YoukuAuthenticationOptions> options,
           ConfigureOptions<YoukuAuthenticationOptions> configureOptions = null)
            : base(next, dataProtectionProvider, loggerFactory, encoder, externalOptions, options, configureOptions)
        {
        }

        /// <summary>
		/// Provides the <see cref="AuthenticationHandler" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler" /> configured with the <see cref="YoukuAuthenticationOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<YoukuAuthenticationOptions> CreateHandler()
        {
            return new YoukuAuthenticationHandler(Backchannel);
        }
    }
}
