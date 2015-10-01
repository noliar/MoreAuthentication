using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DevZH.AspNet.Authentication.Internal
{
    internal static class EnumExtensions
    {
        internal static TEnum ToEnum<TEnum>(this string value) where TEnum : struct
        {
            TEnum tmp;
            Enum.TryParse(value, true, out tmp);
            return tmp;
        }

        internal static string ToLower<TEnum>(this TEnum value)
            where TEnum : struct
            => value.ToString().ToLower();

        // sth. to display
        internal static string GetDescription<TEnum>(this TEnum value) where TEnum: struct
        {
            var type = value.GetType();
            // 解决方案来自 https://github.com/dotnet/coreclr/issues/760
            // 但是为什么 CoreCLR 不能直接 Type.IsEnum 呢，明明 CoreCLR 的 mscorelib 里有这个属性
            if (!type.GetTypeInfo().IsEnum)
            {
                throw new NotSupportedException("类型不支持");
            }
            var name = Enum.GetName(type, value);
            return (type.GetField(name)?.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[])?.Single()?.Description;
        }
    }
}
