using MVCMultiLayer.Interfaces.DAL.Context;
using System.Data.Entity;

namespace MVCMultiLayer.DAL.Context
{
    public class GeneralDbContext : DbContext, IDbContext
    {
        public GeneralDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
