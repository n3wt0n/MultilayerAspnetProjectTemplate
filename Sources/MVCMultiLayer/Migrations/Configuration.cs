using MVCMultiLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MVCMultiLayer.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {            
            if (!context.Roles.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var role = new IdentityRole { Name = Roles.Administrator };
                manager.Create(role);

                role = new IdentityRole { Name = Roles.Manager };
                manager.Create(role);

                role = new IdentityRole { Name = Roles.User };
                manager.Create(role);
            }

            if (!context.Users.Any())
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser { UserName = "s_u", Email = "info@dbtek.com.hk", EmailConfirmed = true};
                manager.Create(user, "dbtek!2016");
                manager.AddToRole(user.Id, Roles.Administrator);

                user = new ApplicationUser { UserName = "manager", Email = "davide@dbtek.com.hk", EmailConfirmed = true};
                manager.Create(user, "manager!2016");
                manager.AddToRole(user.Id, Roles.Manager);                

                user = new ApplicationUser { UserName = "davide", Email = "davide.benvegnu@outlook.com", EmailConfirmed = true, };
                manager.Create(user, "Gavioli!2016");
                manager.AddToRole(user.Id, Roles.User);
               
            }
        }
    }
}
