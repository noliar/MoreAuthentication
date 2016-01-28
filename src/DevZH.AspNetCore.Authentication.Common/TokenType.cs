using System.ComponentModel.DataAnnotations;

namespace DevZH.AspNetCore.Authentication.Common
{
    /// <summary>
    ///  指示请求所需要令牌的类型，一般资源服务器都实现了 None 和 Bearer 。
    /// </summary>
    public enum TokenType
    {
        None,    // 一般是指 AccessToken 不放在 Authorization 头中
        [Display(Description = "bearer")]
        Bearer,  // 一般仅仅将 AccessToken 放在 Authorization中，并指定为 Bearer 模式
        [Display(Description = "mac")]
        MAC      // 经过一定的算法（通常是 HmacSha1 或 HmacSha256）计算，以一定的格式，将相关数据放在 Authorization中，并指定为 MAC 模式
    }
}
