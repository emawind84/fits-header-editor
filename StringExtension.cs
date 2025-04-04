using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitsHeaderEditor
{
    public static class StringExtension
    {
        internal static string SafeSubstring(this string str, int startIndex, int length, char fillChar)
        {
            if (startIndex >= str.Length)
            {
                return new string(fillChar, length);
            }

            if (startIndex + length > str.Length)
            {
                string substring = str.Substring(startIndex);
                return substring + new string(fillChar, length - substring.Length);
            }

            return str.Substring(startIndex, length);
        }
    }
}
