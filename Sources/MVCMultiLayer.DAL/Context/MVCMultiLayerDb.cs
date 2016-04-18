using MVCMultiLayer.DAL.Entities;
using System.Data.Entity;

namespace MVCMultiLayer.DAL.Context
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
