using $safeprojectname$.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace $safeprojectname$.Extensions
{
    public static class IdentityUserRoleExtensions
    {
        public static string RoleName(this IdentityUserRole iuRole)
        {
            if (iuRole == null)
                return string.Empty;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var role = db.Roles.Where(r => r.Id == iuRole.RoleId).FirstOrDefault();

                return role?.Name ?? string.Empty;
            }
        }
    }
}