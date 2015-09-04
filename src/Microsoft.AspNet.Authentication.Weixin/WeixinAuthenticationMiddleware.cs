using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;
using System;

namespace Microsoft.AspNet.Authentication.Weixin
{
    /// <summary>
	/// An ASP.NET middleware for authenticating users using Weixin.
	/// </summary>
    public class WeixinAuthenticationMiddleware : OAuthAuthenticationMiddleware<WeixinAuthenticationOptions>
    {
        /// <summary>
		/// Initializes a new <see cref="WeixinAuthenticationMiddleware" />.
		/// </summary>
		/// <param name="next">The next middleware in the application pipeline to invoke.</param>
		/// <param name="options">Configuration options for the middleware.</param>
        public WeixinAuthenticationMiddleware(
           [NotNull] RequestDelegate next,
           [NotNull] IDataProtectionProvider dataProtectionProvider,
           [NotNull] ILoggerFactory loggerFactory,
           [NotNull] IUrlEncoder encoder,
           [NotNull] IOptions<SharedAuthenticationOptions> sharedOptions,
           [NotNull] IOptions<WeixinAuthenticationOptions> options,
           ConfigureOptions<WeixinAuthenticationOptions> configureOptions = null)
            : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options, configureOptions)
        {
            if (string.IsNullOrWhiteSpace(Options.AppId))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppId)} 值非法");
            }
            if (string.IsNullOrWhiteSpace(Options.AppSecret))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppSecret)} 值非法");
            }
            if(Options.Scope.Count == 0)
            {
                Options.Scope.Add("snsapi_login");
                Options.Scope.Add("snsapi_userinfo");
            }
        }

        /// <summary>
		/// Provides the <see cref="AuthenticationHandler" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler" /> configured with the <see cref="WeixinAuthenticationOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<WeixinAuthenticationOptions> CreateHandler()
        {
            return new WeixinAuthenticationHandler(Backchannel);
        }
    }
}
