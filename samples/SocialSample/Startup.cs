using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication;
using DevZH.AspNet.Authentication.Baidu;
using DevZH.AspNet.Authentication.Common;
using DevZH.AspNet.Authentication.NetEase;
using Microsoft.AspNet.Authentication.Cookies;
using DevZH.AspNet.Authentication.Sina;
using DevZH.AspNet.Authentication.Taobao;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;

namespace SocialSample
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options => options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole(LogLevel.Information);

            app.UseCookieAuthentication(options =>
            {
                options.AutomaticAuthentication = true;
                options.LoginPath = new PathString("/login");
            });

            // 测试应用，其他用户不能登，除非手动添加。
            // 本来打算用 BAE 测试的，只是最近 BAE 大改了，旧版管理界面的API 都失效，看不了 KEY 和 SECRET 了，蛋疼
            app.UseDoubanAuthentication(options =>
            {
                options.ApiKey = "00d08dfa114c80200271a9ee33e58060";
                options.Secret = "39e079a2c685fbb4";
            });

            // 下面几个全都是凑数的
            app.UseBaiduAuthentication(options =>
            {
                options.AccessKeyId = "00d08dfa114c80200271a9ee33e58060";
                options.SecretAccessKey = "39e079a2c685fbb4";
                options.Display = BaiduOptions.DisplayStyle.Touch;
                options.IsForce = true;
                options.UseSms = true;
            });

            app.UseNetEaseAuthentication(options =>
            {
                options.Key = "00d08dfa114c80200271a9ee33e58060";
                options.Secret = "39e079a2c685fbb4";
            });

            app.UseSinaAuthentication(options =>
            {
                options.AppKey = "00d08dfa114c80200271a9ee33e58060";
                options.AppSecret = "39e079a2c685fbb4";
                options.Language = SinaOptions.LanguageType.English;
                options.Display = SinaOptions.DisplayStyle.Mobile;
            });

            app.UseTaobaoAuthentication(options =>
            {
                options.ClientId = "00d08dfa114c80200271a9ee33e58060";
                options.ClientSecret = "39e079a2c685fbb4";
                options.View = TaobaoOptions.ViewStyle.Tmall;
            });

            app.UseTencentAuthentication(options =>
            {
                options.AppId = "00d08dfa114c80200271a9ee33e58060";
                options.AppKey = "39e079a2c685fbb4";
                options.IsMobile = true;
            });

            app.UseWeChatAuthentication(options =>
            {
                options.AppId = "00d08dfa114c80200271a9ee33e58060";
                options.AppSecret = "39e079a2c685fbb4";
            });

            app.UseXiaoMiAuthentication(options =>
            {
                options.AppId = "00d08dfa114c80200271a9ee33e58060";
                options.AppSecret = "39e079a2c685fbb4";
                options.SkpConfirm = true;
                options.TokenType = TokenType.MAC;
            });

            app.UseYixinAuthentication(options =>
            {
                options.AppId = "00d08dfa114c80200271a9ee33e58060";
                options.AppSecret = "39e079a2c685fbb4";
            });

            app.UseYoukuAuthentication(options =>
            {
                options.ClientId = "00d08dfa114c80200271a9ee33e58060";
                options.ClientSecret = "39e079a2c685fbb4";
            });

            // Choose an authentication type
            app.Map("/login", signoutApp =>
            {
                signoutApp.Run(async context =>
                {
                    var authType = context.Request.Query["authscheme"];
                    if (!string.IsNullOrEmpty(authType))
                    {
                        // By default the client will be redirect back to the URL that issued the challenge (/login?authtype=foo),
                        // send them to the home page instead (/).
                        await context.Authentication.ChallengeAsync(authType, new AuthenticationProperties() { RedirectUri = "/" });
                        return;
                    }

                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync("<html><body>");
                    await context.Response.WriteAsync("Choose an authentication scheme: <br>");
                    foreach (var type in context.Authentication.GetAuthenticationSchemes())
                    {
                        await context.Response.WriteAsync("<a href=\"?authscheme=" + type.AuthenticationScheme + "\">" + (type.DisplayName ?? "(suppressed)") + "</a><br>");
                    }
                    await context.Response.WriteAsync("</body></html>");
                });
            });


            // Sign-out to remove the user cookie.
            app.Map("/logout", signoutApp =>
            {
                signoutApp.Run(async context =>
                {
                    context.Response.ContentType = "text/html";
                    await context.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await context.Response.WriteAsync("<html><body>");
                    await context.Response.WriteAsync("You have been logged out. Goodbye " + context.User.Identity.Name + "<br>");
                    await context.Response.WriteAsync("<a href=\"/\">Home</a>");
                    await context.Response.WriteAsync("</body></html>");
                });
            });

            // Deny anonymous request beyond this point.
            app.Use(async (context, next) =>
            {
                if (!context.User.Identities.Any(identity => identity.IsAuthenticated))
                {
                    // The cookie middleware will intercept this 401 and redirect to /login
                    await context.Authentication.ChallengeAsync();
                    return;
                }
                await next();
            });

            // Display user information
            app.Run(async context =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("<html><body>");
                await context.Response.WriteAsync("Hello " + (context.User.Identity.Name ?? "anonymous") + "<br>");
                foreach (var claim in context.User.Claims)
                {
                    await context.Response.WriteAsync(claim.Type + ": " + claim.Value + "<br>");
                }
                await context.Response.WriteAsync("<a href=\"/logout\">Logout</a>");
                await context.Response.WriteAsync("</body></html>");
            });
        }
    }
}
