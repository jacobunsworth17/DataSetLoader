using System;
using System.Collections.Generic;
using System.Text;

namespace DataSetLoader
{
    public static class StringExtensions
    {
        public static int? ConvertToNullableInt(this string s)
        {
            if (int.TryParse(s, out int i)) return i;
            return null;
        }

        public static decimal? ConvertToNullableDecimal(this string s)
        {
            if (decimal.TryParse(s, out decimal d)) return d;
            return null;
        }

        public static TimeSpan? ConvertToNullableTimeSpan(this string s)
        {
            if (TimeSpan.TryParse(s, out TimeSpan t)) return t;
            return null;
        }
    }
}
