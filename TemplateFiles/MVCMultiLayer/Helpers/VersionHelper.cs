using System.IO;
using System.Reflection;
using System.Web.Mvc;

namespace $safeprojectname$.Helpers
{
    /// <summary>
    /// Helper for Application version and update date
    /// </summary>
    public static class VersionHelper
    {
        /// <summary>
        /// Returns the current application assembly version, with only the first 3 values
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString AppCurrentVersion(this HtmlHelper htmlHelper)
        {
            string version = "v." + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            version = version.Remove(version.LastIndexOf('.'));

            return new MvcHtmlString(version);
        }

        /// <summary>
        /// Returns the current application assembly date of update
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString AppCurrentVersionDate(this HtmlHelper htmlHelper)
        {
            string updateDate = File.GetLastWriteTime(Assembly.GetAssembly(typeof(MvcApplication)).Location).ToShortDateString();

            return new MvcHtmlString(updateDate);
        }
    }
}
