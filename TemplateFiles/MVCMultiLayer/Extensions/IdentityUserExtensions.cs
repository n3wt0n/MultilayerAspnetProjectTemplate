using $safeprojectname$.Models;
using System.Linq;

namespace $safeprojectname$.Extensions
{
    public static class IdentityUserExtensions
    {
        public static bool IsInRole(this ApplicationUser user, string roleName)
            => user?.Roles?.Where(r => r.RoleName().ToUpper() == roleName?.ToUpper().Trim()).Any() ?? false;
    }
}