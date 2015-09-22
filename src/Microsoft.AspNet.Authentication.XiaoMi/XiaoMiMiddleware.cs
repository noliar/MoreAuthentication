using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;
using System;


namespace Microsoft.AspNet.Authentication.XiaoMi
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using the Xiao Mi Account service.
    /// </summary>
    public class XiaoMiMiddleware : OAuthMiddleware<XiaoMiOptions>
    {
        /// <summary>
        /// Initializes a new <see cref="XiaoMiMiddleware" />.
        /// </summary>
        /// <param name="next">The next middleware in the application pipeline to invoke.</param>
        /// <param name="dataProtectionProvider"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="encoder"></param>
        /// <param name="sharedOptions"></param>
        /// <param name="options">Configuration options for the middleware.</param>
        public XiaoMiMiddleware(
           [NotNull] RequestDelegate next,
           [NotNull] IDataProtectionProvider dataProtectionProvider,
           [NotNull] ILoggerFactory loggerFactory,
           [NotNull] IUrlEncoder encoder,
           [NotNull] IOptions<SharedAuthenticationOptions> sharedOptions,
           [NotNull] XiaoMiOptions options)
            : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options)
        {
            if (string.IsNullOrWhiteSpace(Options.AppId))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppId)} 值非法");
            }
            if (string.IsNullOrWhiteSpace(Options.AppSecret))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppSecret)} 值非法");
            }
            if (Options.Scope.Count == 0)
            {
                Options.Scope.Add("1");
            }
        }

        /// <summary>
		/// Provides the <see cref="AuthenticationHandler{TOptions}" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler{TOptions}" /> configured with the <see cref="XiaoMiOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<XiaoMiOptions> CreateHandler()
        {
            return new XiaoMiHandler(Backchannel);
        }
    }
}
