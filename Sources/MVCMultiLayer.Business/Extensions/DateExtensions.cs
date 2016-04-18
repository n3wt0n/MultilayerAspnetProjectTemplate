using System;

namespace MVCMultiLayer.Business.Extensions
{
    public static class DateExtensions
    {
        public static string ToShortDateString(this DateTime? date)
            => date?.ToShortDateString() ?? string.Empty;
    }
}
