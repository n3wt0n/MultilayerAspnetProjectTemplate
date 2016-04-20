using System;

namespace $safeprojectname$.Extensions
{
    public static class DateExtensions
    {
        public static string ToShortDateString(this DateTime? date)
            => date?.ToShortDateString() ?? string.Empty;
    }
}
