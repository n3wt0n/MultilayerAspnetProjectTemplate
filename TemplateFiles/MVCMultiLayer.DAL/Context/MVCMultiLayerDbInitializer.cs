using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Context
{
#if DEBUG
    //public class MVCMultiLayerDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<MVCMultiLayerDb>
    //public class MVCMultiLayerDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MVCMultiLayerDb>    
    public class MVCMultiLayerDbInitializer : System.Data.Entity.MigrateDatabaseToLatestVersion<MVCMultiLayerDb, Migrations.Configuration>
#else
    //public class MVCMultiLayerDbInitializer : System.Data.Entity.CreateDatabaseIfNotExists<MVCMultiLayerDb>
    public class MVCMultiLayerDbInitializer : System.Data.Entity.MigrateDatabaseToLatestVersion<MVCMultiLayerDb, Migrations.Configuration>
#endif
    {
        //protected override void Seed(ArtsDiscoverDb context)
        //{
        
        //      //Do Something with the context

        //    context.SaveChanges();

        //    base.Seed(context);


        //}
    }
}
