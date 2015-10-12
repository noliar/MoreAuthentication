# More Authentication Middleware for ASP.NET 5  [![License][License]](LICENSE-2.0.txt)

This project is an ASP.NET 5 middleware that enables an application to support more authentication workflow.

[License]: https://img.shields.io/badge/license-Apache_2.0-blue.svg?style=flat-square

### 目前支持的授权平台
- [x] [360 OAuth2.0 授权](http://wiki.dev.app.360.cn/index.php?title=OAuth2.0%E6%96%87%E6%A1%A3)
- [x] [百度 OAuth2.0 授权](http://developer.baidu.com/wiki/index.php?title=docs/oauth)
- [x] [豆瓣 OAuth2.0 授权](https://developers.douban.com/wiki/?title=oauth2)
- [x] [淘宝 OAuth2.0 授权](http://open.taobao.com/doc/category_list.htm?id=199)
- [x] [腾讯 OAuth2.0 授权](http://wiki.open.qq.com/wiki/website/OAuth2.0%E5%BC%80%E5%8F%91%E6%96%87%E6%A1%A3)
- [x] [网易 OAuth2.0 授权](http://reg.163.com/help/help_oauth2.html)
- [x] [微信 OAuth2.0 授权](https://open.weixin.qq.com/cgi-bin/showdocument?action=dir_list&id=open1419316505)
- [x] [新浪 OAuth2.0 授权](http://open.weibo.com/wiki/%E6%8E%88%E6%9D%83%E6%9C%BA%E5%88%B6%E8%AF%B4%E6%98%8E)
- [x] [小米 OAuth2.0 授权](http://dev.xiaomi.com/docs/passport/way/)
- [x] [优酷 OAuth2.0 授权](http://open.youku.com/docs?id=100)
- [x] [易信 OAuth2.0 授权](https://open.yixin.im/document/oauth/web)

> ### 更多关于 OAuth 2.0 的信息，可参考 [oauth.net](http://oauth.net/2/) 和 [OAuth 2.0 中文文档](https://github.com/jeansfish/RFC6749.zh-cn/blob/master/TableofContents.md)。

## 使用步骤
该项目是根据 [ASP.NET 5 Security](https://github.com/aspnet/Security) 写的众多账号平台授权登录。

所以，你可以跟 `Microsoft.AspNet.Authentication.*` 下的众多账号授权组件一样使用：

1. 在 `Startup` 中的 `ConfigureServices` 添加配置 Identity、Token、Authentication、CookieAuthentication 等服务
2. 在 `Startup` 中的 `Configure` 里 直接添加配置并使用 这些服务。

## 示例代码
在这里，就贴关键的部分（以豆瓣为例），有关账号授权的较为完整代码，建议参考官方提供的例子 —— 
[Music Store](https://github.com/aspnet/MusicStore/tree/dev) 或者查看 [Security sample](https://github.com/aspnet/Security/tree/dev/samples)

根据[文档][store-with-secretmanager]建议，开发时可使用 [Microsoft.Framework.SecretManager][UserSecrets] 存储相关数据，
需要在 ConfigureServices 中使用 `IConfigurationBuilder.AddUserSecrets()`

目前大概有两种方法添加数据，一种是命令行（必须确保 `project.json` 中 `userSecretsId` 值唯一）；另一种是在 Visual Studio 右键项目中，点击“管理用户机密”，会自动添加 `userSecretsId`。

1. Visual Studio 2015 默认没有将 dnx runtime 放入 %PATH% 中，所以必须先将其放入，或者使用 `dnvm upgrade` 自动添加
2. dnu commands install Microsoft.Framework.SecretManager
3. user-secret set Authentication:Douban:ApiKey 00d***060
4. user-secret set Authentication:Douban:Secret 39**b4

[store-with-secretmanager]: http://docs.asp.net/en/latest/security/sociallogins.html#use-secretmanager-to-store-facebook-appid-and-appsecret
[UserSecrets]: https://github.com/aspnet/UserSecrets

打开项目机密文件，可以得到类似这样的 json 结构：
```
{
  "Authentication:Douban:ApiKey": "00d***060",
  "Authentication:Douban:Secret": "39**b4"
}
```

``` csharp
...
// ConfigureServices 下
services.AddAuthentication(options => options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);

...
// Configure 下
app.UseDoubanAuthentication(options =>
{
    options.ApiKey = Configuration["Authentication:Douban:ApiKey"];
    options.Secret = Configuration["Authentication:Douban:Secret"];
});

...
```

## 注意
目前，仅在 ASP.NET 5 beta6+ 有效；也不要在意命名空间名→_→实在想不出什么名好，只好搞统一了。
最后要说的，也是显而易见的是，目前的授权模式为 ***Server-side***
