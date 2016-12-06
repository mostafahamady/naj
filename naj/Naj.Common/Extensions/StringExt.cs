using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Naj.Common
{
    public static class StringExt
    {
        public static string RemoveSymbols(this string source)
        {
            var result = source;
            IEnumerable<Char> symbols = new char[] { 'ـ', '-', '(', ')', '+', '"', '.' };
            foreach (var s in symbols)
                result = result.Replace(s.ToString(), string.Empty);
            return Regex.Replace(result, @"\s+", " ").Trim();
        }
    }
}