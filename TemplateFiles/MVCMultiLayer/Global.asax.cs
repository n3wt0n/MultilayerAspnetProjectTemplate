using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace $safeprojectname$
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Web.Mvc.ModelBinders.Binders.Add(typeof(DateTime?), new ModelBinders.DateTimeModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(decimal?), new ModelBinders.DecimalModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(double?), new ModelBinders.DoubleModelBinder());
        }
    }
}
