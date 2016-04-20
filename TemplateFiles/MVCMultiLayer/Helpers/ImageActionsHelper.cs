using $safeprojectname$.Business.Extensions;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace $safeprojectname$.Helpers
{
    public static class ImageActionsHelper
    {
        /// <summary>
        /// Create an ActionLink with an associated glyphicon
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText"></param>
        /// <param name="actionName"></param>
        /// <param name="glyphicon"></param>
        /// <param name="routeValues"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString GlyphiconActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string glyphicon, object routeValues = null, object htmlAttributes = null)
        {
            if (routeValues != null)
                return GlyphiconActionLink(htmlHelper, linkText, actionName, null, glyphicon, new RouteValueDictionary(routeValues), htmlAttributes);
            else
                return GlyphiconActionLink(htmlHelper, linkText, actionName, null, glyphicon, null, htmlAttributes);
        }

        /// <summary>
        /// Create an ActionLink with an associated glyphicon
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText"></param>
        /// <param name="actionName"></param>
        /// <param name="glyphicon"></param>
        /// <param name="routeValues"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString GlyphiconActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string glyphicon, RouteValueDictionary routeValues = null, object htmlAttributes = null)
            => GlyphiconActionLink(htmlHelper, linkText, actionName, null, glyphicon, routeValues, htmlAttributes);

        /// <summary>
        /// Create an ActionLink with an associated glyphicon
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <param name="glyphicon"></param>
        /// <param name="routeValues"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString GlyphiconActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string glyphicon, object routeValues, object htmlAttributes = null)
            => GlyphiconActionLink(htmlHelper, linkText, actionName, controllerName, glyphicon, new RouteValueDictionary(routeValues), htmlAttributes);

        /// <summary>
        /// Create an ActionLink with an associated glyphicon
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <param name="glyphicon"></param>
        /// <param name="routeValues"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString GlyphiconActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string glyphicon, RouteValueDictionary routeValues = null, object htmlAttributes = null)
        {
            //Exemple of result:
            //<a href="@Url.Action("Edit", new { id = Model.id_rod })">
            //  <i class="glyphicon glyphicon-pencil"></i>
            //  <span>Edit</span>
            //</a>

            routeValues = routeValues.FixIEnumerables();

            var builderI = new TagBuilder("i");
            builderI.MergeAttribute("class", "glyphicon " + glyphicon);
            string iTag = builderI.ToString(TagRenderMode.Normal);

            string spanTag = "";
            if (!string.IsNullOrEmpty(linkText))
            {
                var builderSPAN = new TagBuilder("span");
                builderSPAN.InnerHtml = " " + linkText;
                spanTag = builderSPAN.ToString(TagRenderMode.Normal);
            }

            //Create the "a" tag that wraps
            var builderA = new TagBuilder("a");

            var requestContext = HttpContext.Current.Request.RequestContext;
            var uh = new UrlHelper(requestContext);

            builderA.MergeAttribute("href", uh.Action(actionName, controllerName, routeValues));

            if (htmlAttributes != null)
            {
                IDictionary<string, object> attributes = new RouteValueDictionary(htmlAttributes);
                builderA.MergeAttributes(attributes);
            }

            builderA.InnerHtml = iTag + spanTag;

            return new MvcHtmlString(builderA.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Create an ActionLink with an associated image
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText"></param>
        /// <param name="actionName"></param>
        /// <param name="imagePath"></param>
        /// <param name="routeValues"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ImageActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string imagePath, object routeValues = null, object htmlAttributes = null)
            => ImageActionLink(htmlHelper, linkText, actionName, null, imagePath, routeValues, htmlAttributes);

        /// <summary>
        /// Create an ActionLink with an associated image
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <param name="imagePath"></param>
        /// <param name="routeValues"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ImageActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string imagePath, object routeValues = null, object htmlAttributes = null)
        {
            //Exemple of result:
            //<a href="@Url.Action("Edit", new { id = Model.id_rod })">
            //  <i class="glyphicon glyphicon-pencil"></i>
            //  <span>Edit</span>
            //</a>

            if (imagePath.StartsWith("~/"))
                imagePath = VirtualPathUtility.ToAbsolute(imagePath);

            var builderImage = new TagBuilder("image");
            builderImage.MergeAttribute("src", imagePath);
            builderImage.MergeAttribute("alt", linkText);
            builderImage.MergeAttribute("style", "border=0");
            string imageTag = builderImage.ToString(TagRenderMode.SelfClosing);

            string spanTag = "";
            if (!string.IsNullOrEmpty(linkText))
            {
                var builderSPAN = new TagBuilder("span");
                builderSPAN.InnerHtml = " " + linkText;
                spanTag = builderSPAN.ToString(TagRenderMode.Normal);
            }

            //Create the "a" tag that wraps
            var builderA = new TagBuilder("a");

            var requestContext = HttpContext.Current.Request.RequestContext;
            var uh = new UrlHelper(requestContext);

            var routeValuesDict = new RouteValueDictionary(routeValues);
            routeValuesDict = routeValuesDict.FixIEnumerables();

            builderA.MergeAttribute("href", uh.Action(actionName, controllerName, routeValuesDict));

            if (htmlAttributes != null)
            {
                IDictionary<string, object> attributes = new RouteValueDictionary(htmlAttributes);
                builderA.MergeAttributes(attributes);
            }

            builderA.InnerHtml = imageTag + spanTag;

            return new MvcHtmlString(builderA.ToString(TagRenderMode.Normal));
        }

        #region Ajax
        public static MvcHtmlString GlyphiconActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, string glyphicon, AjaxOptions ajaxOptions, object routeValues = null, object htmlAttributes = null)
            => GlyphiconActionLink(ajaxHelper, linkText, actionName, controllerName, glyphicon, ajaxOptions, new RouteValueDictionary(routeValues), htmlAttributes);

        /// <summary>
        /// Create an Ajax.ActionLink with an associated glyphicon
        /// </summary>
        /// <param name="ajaxHelper"></param>
        /// <param name="linkText"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <param name="glyphicon"></param>
        /// <param name="ajaxOptions"></param>
        /// <param name="routeValues"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString GlyphiconActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, string glyphicon, AjaxOptions ajaxOptions, RouteValueDictionary routeValues = null, object htmlAttributes = null)
        {
            //Exemple of result:           
            //<a id="btnShow" href="/Customers/ShowArtworks?customerId=1" data-ajax-update="#pnlArtworks" data-ajax-success="jsSuccess" 
            //data-ajax-mode="replace" data-ajax-method="POST" data-ajax-failure="jsFailure" data-ajax-confirm="confirm" data-ajax-complete="jsComplete" 
            //data-ajax-begin="jsBegin" data-ajax="true">
            //  <i class="glyphicon glyphicon-pencil"></i>
            //  <span>Edit</span>
            //</a>

            var builderI = new TagBuilder("i");
            builderI.MergeAttribute("class", "glyphicon " + glyphicon);
            string iTag = builderI.ToString(TagRenderMode.Normal);

            string spanTag = "";
            if (!string.IsNullOrWhiteSpace(linkText))
            {
                var builderSPAN = new TagBuilder("span");
                builderSPAN.InnerHtml = " " + linkText;
                spanTag = builderSPAN.ToString(TagRenderMode.Normal);
            }

            //Create the "a" tag that wraps
            var builderA = new TagBuilder("a");

            var uh = new UrlHelper(HttpContext.Current.Request.RequestContext);

            builderA.MergeAttribute("href", uh.Action(actionName, controllerName, routeValues.FixIEnumerables()));

            //Ajax section
            builderA.MergeAttribute("data-ajax", "true");
            builderA.MergeAttribute("data-ajax-update", ajaxOptions.UpdateTargetId.StartsWith("#") ? ajaxOptions.UpdateTargetId : "#" + ajaxOptions.UpdateTargetId);

            if (!string.IsNullOrEmpty(ajaxOptions.InsertionMode.ToString()))
                builderA.MergeAttribute("data-ajax-mode", ajaxOptions.InsertionMode.ToString());

            if (!string.IsNullOrEmpty(ajaxOptions.OnBegin))
                builderA.MergeAttribute("data-ajax-begin", ajaxOptions.OnBegin);

            if (!string.IsNullOrEmpty(ajaxOptions.OnComplete))
                builderA.MergeAttribute("data-ajax-complete", ajaxOptions.OnComplete);

            if (!string.IsNullOrEmpty(ajaxOptions.OnFailure))
                builderA.MergeAttribute("data-ajax-failure", ajaxOptions.OnFailure);

            if (!string.IsNullOrEmpty(ajaxOptions.OnSuccess))
                builderA.MergeAttribute("data-ajax-success", ajaxOptions.OnSuccess);

            if (!string.IsNullOrEmpty(ajaxOptions.Confirm))
                builderA.MergeAttribute("data-ajax-confirm", ajaxOptions.Confirm);

            if (!string.IsNullOrEmpty(ajaxOptions.HttpMethod))
                builderA.MergeAttribute("data-ajax-method", ajaxOptions.HttpMethod);

            if (htmlAttributes != null)
            {
                IDictionary<string, object> attributes = new RouteValueDictionary(htmlAttributes);
                builderA.MergeAttributes(attributes);
            }

            builderA.InnerHtml = iTag + spanTag;

            return new MvcHtmlString(builderA.ToString(TagRenderMode.Normal));
        }
        #endregion
    }
}