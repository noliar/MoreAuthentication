using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.AspNet.Authentication.Internal
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

        /*internal static string GetDescription<TEnum>(this TEnum value) where TEnum: struct
        {
            var type = value.GetType();
            if (!type.IsEnum)
            {
                throw new NotSupportedException("类型不支持");
            }
            var name = Enum.GetName(type, value);
            return (type.GetField(name)?.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[])?.Single()?.Description;
        }*/
    }
}
