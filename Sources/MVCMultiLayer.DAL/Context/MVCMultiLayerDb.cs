using MVCMultiLayer.DAL.Entities;
using System.Data.Entity;

namespace MVCMultiLayer.DAL.Context
{
    public class MVCMultiLayerDb : GeneralDbContext
    {
        public MVCMultiLayerDb() 
            : base("MVCMultiLayerConnection")
        {
            
        }

        public DbSet<Example> Volunteers { get; set; }
       
    }
}
