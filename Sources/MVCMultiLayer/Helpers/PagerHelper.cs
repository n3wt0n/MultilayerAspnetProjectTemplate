using MVCMultiLayer.Business.Extensions;
using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace MVCMultiLayer.Helpers
{
    public static class PagerHelper
    {
        /// <summary>
        /// Create the Pager with buttons for numbers
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="Action"></param>
        /// <param name="Controller"></param>
        /// <param name="page"></param>
        /// <param name="pageCount"></param>
        /// <param name="routeValues"></param>
        /// <param name="additionalCssClasses"></param>
        /// <returns></returns>
        public static MvcHtmlString PagerButtons(this HtmlHelper htmlHelper, string Action, string Controller, int? page, int? pageCount, object routeValues = null, string additionalCssClasses = "")
        {
            //FORMAT
            //<div class="btn-toolbar" role="toolbar">
            //  <div class="btn-group">
            //      <button type="button" class="btn btn-default">1</button>
            //      <button type="button" class="btn btn-default">2</button>
            //  </div>
            //  <div class="btn-group">...</div>
            //  <div class="btn-group">...</div>
            //</div>

            //RESULT
            // <<  1  10  20  30  31  32  33  34  35  36  37  38  39  40  50  53  >>

            string rtn = "";
            if (page.HasValue && pageCount.HasValue)
            {
                string wrapper = "<div class=\"btn-toolbar\" role=\"toolbar\">" +
                                  " {0}" +
                                  "</div>";

                string group = "   <div class=\"btn-group\">" +
                                "       {0}" +
                                "   </div>";

                object attribObj;
                if (page.Value == 1)
                    attribObj = new { @class = "btn btn-default " + additionalCssClasses, disabled = "disabled" };
                else
                    attribObj = new { @class = "btn btn-default " + additionalCssClasses };

                var routeValuesDict = new RouteValueDictionary(routeValues);
                routeValuesDict = routeValuesDict.FixIEnumerables();

                routeValuesDict.Add("page", page.Value - 1);

                var btnPrev = ImageActionsHelper.GlyphiconActionLink(htmlHelper, "", Action, Controller, "glyphicon-chevron-left", routeValuesDict, attribObj);

                var numberButtons = new StringBuilder();

                var pageRangeStart = page.Value >= 10 ? RoundDown(page.Value) : 1;
                var pageRangeStop = (pageRangeStart + 10) < pageCount.Value ? pageRangeStart + 10 : pageCount.Value;

                for (int i = 1; i <= pageCount.Value; i++)
                {
                    if (i == 1 || i % 10 == 0 || i == pageCount.Value || (pageRangeStart < i && i < pageRangeStop))
                    {
                        routeValuesDict = new RouteValueDictionary(routeValues);
                        routeValuesDict = routeValuesDict.FixIEnumerables();

                        routeValuesDict.Add("page", i);

                        numberButtons.Append(ImageActionsHelper.GlyphiconActionLink(htmlHelper, i.ToString(), Action, Controller, "", routeValuesDict,
                            new { @class = (i == page.Value ? "btn btn-primary " : "btn btn-default ") + additionalCssClasses }));
                    }
                }

                if (page.Value == pageCount.Value)
                    attribObj = new { @class = "btn btn-default " + additionalCssClasses, disabled = "disabled" };
                else
                    attribObj = new { @class = "btn btn-default " + additionalCssClasses };

                routeValuesDict = new RouteValueDictionary(routeValues);
                routeValuesDict = routeValuesDict.FixIEnumerables();

                routeValuesDict.Add("page", page.Value + 1);

                var btnNext = ImageActionsHelper.GlyphiconActionLink(htmlHelper, "", Action, Controller, "glyphicon-chevron-right", routeValuesDict, attribObj);

                rtn = string.Format(wrapper,
                    (
                        String.Format(group, btnPrev) +
                        String.Format(group, numberButtons.ToString()) +
                        String.Format(group, btnNext)
                    ));
            }

            return new MvcHtmlString(rtn);
        }

        private static int RoundDown(int toRound)
            => toRound - toRound % 10;        

        #region Ajax
        /// <summary>
        /// Create the Pager with buttons for numbers (Ajax version)
        /// </summary>
        /// <param name="ajaxHelper"></param>
        /// <param name="Action"></param>
        /// <param name="Controller"></param>
        /// <param name="page"></param>
        /// <param name="pageCount"></param>
        /// <param name="ajaxOptions"></param>
        /// <param name="routeValues"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString PagerButtons(this AjaxHelper ajaxHelper, string Action, string Controller, int? page, int? pageCount, AjaxOptions ajaxOptions, object routeValues = null, object htmlAttributes = null)
        {
            //FORMAT
            //<div class="btn-toolbar" role="toolbar">
            //  <div class="btn-group">
            //      <button type="button" class="btn btn-default">1</button>
            //      <button type="button" class="btn btn-default">2</button>
            //  </div>
            //  <div class="btn-group">...</div>
            //  <div class="btn-group">...</div>
            //</div>

            string rtn = "";
            if (page.HasValue && pageCount.HasValue)
            {
                string wrapper = "<div class=\"btn-toolbar\" role=\"toolbar\">" +
                          " {0}" +
                          "</div>";

                string group = "   <div class=\"btn-group\">" +
                                "       {0}" +
                                "   </div>";

                object attribObj;
                if (page.Value == 1)
                    attribObj = new { @class = "btn btn-default", disabled = "disabled" };
                else
                    attribObj = new { @class = "btn btn-default" };

                var routeValuesDict = new RouteValueDictionary(routeValues);
                routeValuesDict.Add("page", page.Value - 1);

                var btnPrev = ImageActionsHelper.GlyphiconActionLink(ajaxHelper, "", Action, Controller, "glyphicon-chevron-left",
                    ajaxOptions, routeValuesDict, attribObj);

                var numberButtons = new StringBuilder();

                for (int i = 1; i <= pageCount.Value; i++)
                {
                    routeValuesDict = new RouteValueDictionary(routeValues);
                    routeValuesDict.Add("page", i);

                    numberButtons.Append(ImageActionsHelper.GlyphiconActionLink(ajaxHelper, i.ToString(), Action, Controller, "",
                        ajaxOptions, routeValuesDict,
                        new { @class = i == page.Value ? "btn btn-primary" : "btn btn-default" }));
                }

                if (page.Value == pageCount.Value)
                    attribObj = new { @class = "btn btn-default", disabled = "disabled" };
                else
                    attribObj = new { @class = "btn btn-default" };

                routeValuesDict = new RouteValueDictionary(routeValues);
                routeValuesDict.Add("page", page.Value + 1);

                var btnNext = ImageActionsHelper.GlyphiconActionLink(ajaxHelper, "", Action, Controller, "glyphicon-chevron-right",
                    ajaxOptions, routeValuesDict, attribObj);

                rtn = string.Format(wrapper,
                    (
                        String.Format(group, btnPrev) +
                        String.Format(group, numberButtons.ToString()) +
                        String.Format(group, btnNext)
                    ));
            }

            return new MvcHtmlString(rtn);
        }
        #endregion
    }
}