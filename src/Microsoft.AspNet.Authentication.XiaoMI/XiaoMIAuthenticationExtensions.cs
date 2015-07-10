namespace Microsoft.AspNet.Authentication.XiaoMI
{
    /// <summary>
    ///  一些扩展方法
    /// </summary>
    public static class XiaoMIAuthenticationExtensions
    {
        internal static string ToEscapeData(this string value) => System.Uri.EscapeDataString(value);
    }
}
