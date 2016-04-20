using $safeprojectname$.Business.Extensions;
using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace $safeprojectname$.Helpers
{
    public static class LettersHelper
    {
        private static char[] letters = { '*', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'W', 'Z' };

        /// <summary>
        /// Genrate N buttons with all the alphabet letters
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="Action"></param>
        /// <param name="Controller"></param>
        /// <param name="letter"></param>
        /// <param name="routeValues"></param>
        /// <param name="htmlAttributes"></param>
        /// <param name="selectedIds"></param>
        /// <param name="selectedIdsParamName"></param>
        /// <returns></returns>
        public static MvcHtmlString AlphabetLettersButtons(this HtmlHelper htmlHelper, string Action, string Controller, char? letter, object routeValues = null, object htmlAttributes = null,
            int[] selectedIds = null, string selectedIdsParamName = "")
        {
            //FORMAT
            //if (letter.HasValue)
            //{
            //<div class="btn-toolbar" role="toolbar">
            //  <div class="btn-group">
            //      <button type="button" class="btn btn-default">A</button>
            //      <button type="button" class="btn btn-default">B</button>
            //  </div>
            //  <div class="btn-group">...</div>
            //  <div class="btn-group">...</div>
            //</div>

            string rtn = "";
            string wrapper = "<div class=\"btn-toolbar\" role=\"toolbar\">" +
                              " {0}" +
                              "</div>";

            string group = "   <div class=\"btn-group\">" +
                            "       {0}" +
                            "   </div>";

            var routeValuesDict = new RouteValueDictionary(routeValues);

            var letterButtons = new StringBuilder();

            foreach (var l in letters)
            {
                routeValuesDict = new RouteValueDictionary(routeValues);
                routeValuesDict = routeValuesDict.FixIEnumerables();

                routeValuesDict.Add("letter", l);

                letterButtons.Append(ImageActionsHelper.ImageActionLink(htmlHelper, l.ToString(), Action, Controller, "",
                    routeValuesDict,
                    new { @class = letter.HasValue ? (l == letter.Value ? "btn btn-primary" : "btn btn-default") : "btn btn-default" }));
            }

            rtn = string.Format(wrapper,
                (
                    String.Format(group, letterButtons.ToString())
                ));

            return new MvcHtmlString(rtn);
        }
    }
}