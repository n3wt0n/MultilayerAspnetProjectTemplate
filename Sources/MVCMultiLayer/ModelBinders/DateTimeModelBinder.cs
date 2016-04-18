using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;


namespace MVCMultiLayer.ModelBinders
{
    public class DateTimeModelBinder : IModelBinder
    {
        /// <summary>
        /// Binds the value to the model.
        /// </summary>
        /// <param name="controllerContext">The current controller context.</param>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>The new model.</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var culture = GetUserCulture(controllerContext);

            var valueProviderResult = bindingContext.ValueProvider
                               .GetValue(bindingContext.ModelName);

            if (valueProviderResult != null)
            {
                var value = valueProviderResult.ConvertTo(typeof(string)) as string;
                DateTime result = DateTime.MinValue;

                if (!string.IsNullOrWhiteSpace(value) &&
                    (DateTime.TryParse(value, culture, DateTimeStyles.None, out result)
                    || DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy HH:mm", "dd/MM/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm", "MM/dd/yyyy HH:mm:ss",
                    "dd/MM/yyyy HH.mm", "dd/MM/yyyy HH.mm.ss", "MM/dd/yyyy HH.mm", "MM/dd/yyyy HH.mm.ss",
                    "dd/MM/yyyy", "dd/MM/yyyy"}, CultureInfo.InvariantCulture, DateTimeStyles.None, out result)))
                {
                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the culture used for formatting, based on the user's input language.
        /// </summary>
        /// <param name="context">The controller context.</param>
        /// <returns>An instance of <see cref="CultureInfo" />.</returns>
        public CultureInfo GetUserCulture(ControllerContext context)
        {
            //var request = context.HttpContext.Request;
            //if (request.UserLanguages == null || request.UserLanguages.Length == 0)
            //    return CultureInfo.CurrentUICulture;            

            //return new CultureInfo(request.UserLanguages[0]);

            return Thread.CurrentThread.CurrentCulture;
        }
    }
}