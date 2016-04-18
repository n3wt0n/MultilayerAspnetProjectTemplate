using System.Web.Mvc;

namespace MVCMultiLayer.Attributes
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public RoleAuthorizeAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string[] acceptedTypes = filterContext.HttpContext.Request.AcceptTypes;
                foreach (string type in acceptedTypes)
                {
                    if (type.Contains("html"))
                    {
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                            filterContext.Result = new ViewResult { ViewName = "_AccessDeniedPartial" };
                        else
                            filterContext.Result = new ViewResult { ViewName = "AccessDenied" };
                        break;
                    }
                    else if (type.Contains("javascript"))
                    {
                        filterContext.Result = new JsonResult
                        {
                            Data = new
                            {
                                success = false,
                                message = "Access denied."
                            }
                        };
                        break;
                    }
                    else if (type.Contains("xml"))
                        filterContext.Result = new HttpUnauthorizedResult(); //this will redirect to login page with forms auth you could instead serialize a custom xml payload and return here.                    
                }
            }
            else            
                base.HandleUnauthorizedRequest(filterContext);            
        }
    }
}