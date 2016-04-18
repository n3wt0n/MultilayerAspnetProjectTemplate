using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMultiLayer.Models
{
    public class IdentityDbInitializer : System.Data.Entity.MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>
    {
    }
}