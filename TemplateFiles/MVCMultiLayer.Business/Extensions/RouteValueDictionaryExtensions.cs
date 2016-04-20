using System.Collections;
using System.Linq;
using System.Web.Routing;

namespace $safeprojectname$.Extensions
{
    public static class RouteValueDictionaryExtensions
    {

        public static RouteValueDictionary FixIEnumerables(this RouteValueDictionary routes)
        {
            if (routes == null || !routes.Any())
                return routes;

            var newRv = new RouteValueDictionary();
            foreach (var key in routes.Keys)
            {
                object value = routes[key];
                if (value is IEnumerable && !(value is string))
                {
                    int index = 0;
                    foreach (var val in (IEnumerable)value)
                    {
                        newRv.Add(string.Format("{0}[{1}]", key, index), val.ToString());
                        index++;
                    }
                }
                else
                    newRv.Add(key, value);
            }

            return newRv;
        }
    }
}
