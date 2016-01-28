using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.WebEncoders;

namespace DevZH.AspNetCore.Authentication.Baidu
{
    /// <summary>
    /// An ASP.NET middleware for authenticating users using the Baidu Account service.
    /// </summary>
    public class BaiduMiddleware : OAuthMiddleware<BaiduOptions>
    {
        /// <summary>
        ///  构造一个新的 <see cref="BaiduMiddleware"/>
        /// </summary>
        /// <param name="next">The next middleware in the HTTP pipeline to invoke.</param>
        /// <param name="dataProtectionProvider"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="encoder"></param>
        /// <param name="sharedOptions"></param>
        /// <param name="options">Configuration options for the middleware.</param>
        public BaiduMiddleware(
            RequestDelegate next,
            IDataProtectionProvider dataProtectionProvider,
            ILoggerFactory loggerFactory,
            IUrlEncoder encoder,
            IOptions<SharedAuthenticationOptions> sharedOptions,
            BaiduOptions options) 
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

            if (string.IsNullOrWhiteSpace(Options.AccessKeyId))
            {
                throw new ArgumentException("请输入有效的 Access Key ID 或 API Key");
            }
            if (string.IsNullOrWhiteSpace(Options.SecretAccessKey))
            {
                throw new ArgumentException("请输入有效的 Secret Access Key 或 Secret Key");
            }
            if (Options.Scope.Count == 0)
            {
                Options.Scope.Add("basic");
            }
        }

        /// <summary>
        /// Provides the <see cref="AuthenticationHandler{TOptions}"/> object for processing authentication-related requests.
        /// </summary>
        /// <returns>An <see cref="AuthenticationHandler{TOptions}"/> configured with the <see cref="BaiduHandler"/> supplied to the constructor.</returns>
        protected override AuthenticationHandler<BaiduOptions> CreateHandler()
        {
            return new BaiduHandler(Backchannel);
        }
    }
}