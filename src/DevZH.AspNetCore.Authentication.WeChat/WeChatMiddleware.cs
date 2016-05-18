using System;
using System.Text.Encodings.Web;
using DevZH.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DevZH.AspNetCore.Authentication.WeChat
{
    /// <summary>
	/// An ASP.NET middleware for authenticating users using WeChat.
	/// </summary>
    public class WeChatMiddleware : OAuthMiddleware<WeChatOptions>
    {
        /// <summary>
		/// Initializes a new <see cref="WeChatMiddleware" />.
		/// </summary>
		/// <param name="next">The next middleware in the application pipeline to invoke.</param>
		/// <param name="dataProtectionProvider"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="encoder"></param>
        /// <param name="sharedOptions"></param>
		/// <param name="options">Configuration options for the middleware.</param>
        public WeChatMiddleware(
           RequestDelegate next,
           IDataProtectionProvider dataProtectionProvider,
           ILoggerFactory loggerFactory,
           UrlEncoder encoder,
           IOptions<SharedAuthenticationOptions> sharedOptions,
           IOptions<WeChatOptions> options)
            : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            if (dataProtectionProvider == null)
            {
                throw new ArgumentNullException(nameof(dataProtectionProvider));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (encoder == null)
            {
                throw new ArgumentNullException(nameof(encoder));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrWhiteSpace(Options.AppId))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppId)} 值非法");
            }
            if (string.IsNullOrWhiteSpace(Options.AppSecret))
            {
                throw new ArgumentException($"参数 {nameof(Options.AppSecret)} 值非法");
            }
        }

        /// <summary>
		/// Provides the <see cref="AuthenticationHandler{TOptions}" /> object for processing authentication-related requests.
		/// </summary>
		/// <returns>An <see cref="AuthenticationHandler{TOptions}" /> configured with the <see cref="WeChatOptions" /> supplied to the constructor.</returns>
        protected override AuthenticationHandler<WeChatOptions> CreateHandler()
        {
            return new WeChatHandler(Backchannel);
        }
    }
}
