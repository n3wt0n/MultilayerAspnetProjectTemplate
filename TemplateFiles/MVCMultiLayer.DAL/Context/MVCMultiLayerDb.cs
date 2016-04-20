using $safeprojectname$.Entities;
using System.Data.Entity;

namespace $safeprojectname$.Context
{
    public class MVCMultiLayerDb : GeneralDbContext
    {
        public MVCMultiLayerDb()
            : base("DatabaseConnection")
        {

        }

        public DbSet<Example> Examples { get; set; }

    }
}
