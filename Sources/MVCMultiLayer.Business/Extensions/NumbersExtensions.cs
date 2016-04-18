using System;

namespace MVCMultiLayer.Business.Extensions
{
    public static class NumbersExtensions
    {
        public static string ToFormattedString(this decimal number)
            => number.ToString("N");

        public static string ToFormattedString(this decimal? number)
            => number?.ToFormattedString() ?? string.Empty;       
    }
}
