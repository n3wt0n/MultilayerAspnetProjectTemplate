using MVCMultiLayer.Models;
using System.Web;

namespace MVCMultiLayer.Managers
{
    public class UserManager
    {
        public static bool IsManager()
            => (HttpContext.Current?.User?.IsInRole(Roles.Administrator) ?? false)
                || (HttpContext.Current?.User?.IsInRole(Roles.Manager) ?? false);
    }
}