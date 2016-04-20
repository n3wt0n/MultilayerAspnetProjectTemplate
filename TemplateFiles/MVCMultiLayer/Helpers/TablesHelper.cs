using $safeprojectname$.Business.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace $safeprojectname$.Helpers
{
    public static class TablesHelper
    {
        /// <summary>
        /// Acts as DisplayNameFor but works also with ViewModels
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="model"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString DisplayColumnNameFor<TModel, TClass, TProperty>(this HtmlHelper<TModel> helper, IEnumerable<TClass> model, Expression<Func<TClass, TProperty>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression<TClass, TProperty>(expression, new ViewDataDictionary<TClass>());

            return new MvcHtmlString(metadata.DisplayName ?? metadata.PropertyName.SeparateCapitals());
        }

        /// <summary>
        /// Acts as DisplayNameFor but works also with ViewModels, and makes the header clickable for sorts
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="model"></param>
        /// <param name="expression"></param>
        /// <param name="actionName"></param>
        /// <param name="currentSorting"></param>
        /// <param name="routeValues"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString DisplaySortableColumnNameFor<TModel, TClass, TProperty>(this HtmlHelper<TModel> helper, IEnumerable<TClass> model, Expression<Func<TClass, TProperty>> expression,
            string actionName, string currentSorting = "", object routeValues = null, object htmlAttributes = null)
            => DisplaySortableColumnNameFor(helper, model, expression, actionName, null, currentSorting, routeValues, htmlAttributes);

        /// <summary>
        /// Acts as DisplayNameFor but works also with ViewModels, and makes the header clickable for sorts
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="model"></param>
        /// <param name="expression"></param>
        /// <param name="actionName"></param>
        /// <param name="sortByName"></param>
        /// <param name="currentSorting"></param>
        /// <param name="routeValues"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString DisplaySortableColumnNameFor<TModel, TClass, TProperty>(this HtmlHelper<TModel> helper, IEnumerable<TClass> model, Expression<Func<TClass, TProperty>> expression,
            string actionName, string sortByName = "", string currentSorting = "", object routeValues = null, object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression<TClass, TProperty>(expression, new ViewDataDictionary<TClass>());

            var builderA = new TagBuilder("a");

            var requestContext = HttpContext.Current.Request.RequestContext;
            var uh = new UrlHelper(requestContext);

            var routeValuesDict = new RouteValueDictionary(routeValues).FixIEnumerables();

            if (string.IsNullOrEmpty(sortByName))
                sortByName = metadata.PropertyName;

            bool isCurrent = false;
            bool isDesc = false;

            if (!string.IsNullOrEmpty(currentSorting) && sortByName == currentSorting.Replace(" DESC", ""))
            {
                isCurrent = true;

                if (currentSorting.Contains("DESC"))
                    isDesc = true;
                else
                    sortByName = sortByName + " DESC";
            }

            routeValuesDict.Add("sortBy", sortByName);

            builderA.MergeAttribute("href", uh.Action(actionName, routeValuesDict));

            if (htmlAttributes != null)
            {
                IDictionary<string, object> attributes = new RouteValueDictionary(htmlAttributes);
                builderA.MergeAttributes(attributes);
            }

            string innerHtml = metadata.DisplayName ?? metadata.PropertyName.SeparateCapitals();

            if (isCurrent)
            {
                innerHtml += " <i class=\"glyphicon glyphicon-chevron-{0}\"></i>";
                innerHtml = isDesc ? string.Format(innerHtml, "up") : string.Format(innerHtml, "down");
            }

            builderA.InnerHtml = innerHtml;

            return new MvcHtmlString(builderA.ToString(TagRenderMode.Normal));
        }
    }
}