# More Authentication Middleware for ASP.NET 5

This project is an ASP.NET 5 middleware that enables an application to support the Baidu Account authentication workflow.


## 使用步骤：
该项目是根据 [ASP.NET 5 Security] (https://github.com/aspnet/Security) 写的 百度 OAuth 2.0 账号授权。

所以，你可以跟 Microsoft.AspNet.Authentication.* 下的众多账号授权组件一样使用：

1. 首先，在 Startup 中的 ConfigureServices 添加配置 Identity、Token、CookieAuthentication 等服务
2. 其次，再添加配置 BaiduAuthentication、Session 等服务
3. 最后，在 Startup 中的 Configure 里 开启使用 这些服务。

## 示例代码
在这里，就贴关键的部分，有关账号授权的完整代码，建议参考官方提供的例子 —— [Music Store](https://github.com/aspnet/MusicStore/tree/dev) (前身应该是 MVC Music Store)
``` csharp
// ConfigureServices 下
services.ConfigureBaiduAuthentication(options =>
{
    options.ClientId = "ycC****a8";
    options.ClientSecret = "2ID****B1vA";
    options.Display = BaiduAuthenticationOptions.DisplayStyle.Touch;
    options.CallbackPath = new PathString("/oauth_success"); 
});
...
// Configure 下
app.UseBaiduAuthentication();
```
## 注意
目前，仅在 ASP.NET 5 beta6 有效；也不要在意命名空间名→_→实在想不出什么名好，只好搞统一了。
