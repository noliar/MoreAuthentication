using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Authentication.Common
{
    public static class TokenTypeExtensions
    {
        internal static TEnum ToEnum<TEnum>(this string value) where TEnum : struct
        {
            TEnum tmp;
            Enum.TryParse(value, true, out tmp);
            return tmp;
        }

        public static string ToLower(this TokenType value) => value.ToString().ToLower();
    }
}
