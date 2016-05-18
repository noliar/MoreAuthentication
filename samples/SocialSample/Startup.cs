using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DevZH.AspNetCore.Authentication.Common;
using DevZH.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SocialSample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("config.json");
            if(env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options => options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole(LogLevel.Information);

            // Simple error page to avoid a repo dependency.
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    if (context.Response.HasStarted)
                    {
                        throw;
                    }
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync(ex.ToString());
                }
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = new PathString("/login")
            });

            // 测试应用，其他用户不能登，除非手动添加。
            // 本来打算用 BAE 测试的，只是最近 BAE 大改了，旧版管理界面的API 都失效，看不了 KEY 和 SECRET 了，蛋疼
            // 豆瓣样例
            app.UseDoubanAuthentication(new DoubanOptions
            {
                ApiKey = Configuration["douban:apikey"],
                Secret = Configuration["douban:secret"],

                Events = new OAuthEvents()
                {
                    OnRemoteFailure = ctx =>

                    {
                        ctx.Response.Redirect("/error?FailureMessage=" + UrlEncoder.Default.Encode(ctx.Failure.Message));
                        ctx.HandleResponse();
                        return Task.FromResult(0);
                    }
                }
            });

            #region 下面几个全都是凑数的
            // 百度样例
            app.UseBaiduAuthentication(new BaiduOptions
            {
                AccessKeyId = Configuration["baidu:accesskeyid"],
                SecretAccessKey = Configuration["baidu:secretaccesskey"],
                Display = BaiduOptions.DisplayStyle.Touch,
                IsForce = true,
                UseSms = true
            });

            // 360 样例
            app.UseQihooAuthentication(new QihooOptions
            {
                AppKey = Configuration["qihoo:appkey"],
                AppSecret = Configuration["qihoo:appsecret"],
                ReLogin = "360.cn",
                Display = QihooOptions.DisplayStyle.Desktop
            });

            // 网易样例
            app.UseNetEaseAuthentication(new NetEaseOptions
            {
                Key = Configuration["netease:key"],
                Secret = Configuration["netease:secret"]
            });

            // 新浪样例
            app.UseSinaAuthentication(new SinaOptions
            {
                AppKey = Configuration["sina:appkey"],
                AppSecret = Configuration["sina:appsecret"],
                Language = SinaOptions.LanguageType.English,
                Display = SinaOptions.DisplayStyle.Mobile
            });

            // 淘宝样例
            app.UseTaobaoAuthentication(new TaobaoOptions
            {
                ClientId = Configuration["taobao:clientid"],
                ClientSecret = Configuration["taobao:clientsecret"],
                View = TaobaoOptions.ViewStyle.Tmall
            });

            // QQ 样例
            app.UseTencentAuthentication(new TencentOptions
            {
                AppId = Configuration["tencent:appid"],
                AppKey = Configuration["tencent:appkey"],
                IsMobile = true
            });

            // 微信样例
            app.UseWeChatAuthentication(new WeChatOptions
            {
                AppId = Configuration["wechat:appid"],
                AppSecret = Configuration["wechat:appsecret"]
            });

            // 小米样例
            app.UseXiaoMiAuthentication(new XiaoMiOptions
            {
                AppId = Configuration["xiaomi:appid"],
                AppSecret = Configuration["xiaomi:appsecret"],
                SkpConfirm = true,
                TokenType = TokenType.MAC
            });

            // 易信样例
            app.UseYixinAuthentication(new YixinOptions
            {
                AppId = Configuration["yixin:appid"],
                AppSecret = Configuration["yixin:appkey"]
            });

            // 优酷样例
            app.UseYoukuAuthentication(new YoukuOptions
            {
                ClientId = Configuration["youku:clientid"],
                ClientSecret = Configuration["youku:clientsecret"]
            });
            #endregion

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

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
