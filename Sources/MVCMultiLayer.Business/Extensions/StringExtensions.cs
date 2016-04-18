using System;
using System.Linq;
using System.Web;

namespace MVCMultiLayer.Business.Extensions
{
    public static class StringExtensions
    {
        public static string SeparateCapitals(this string value)
            => string.Concat((value ?? string.Empty).Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart('_').TrimStart(' ');

        public static string HtmlEncodeForQuerystring(this string value)
            => HttpContext.Current.Server.HtmlEncode(value)?.Replace('&', '_');

        public static string HtmlDecodeForQuerystring(this string value)
            => HttpContext.Current.Server.HtmlDecode(value?.Replace('_', '&'));
    }
}
