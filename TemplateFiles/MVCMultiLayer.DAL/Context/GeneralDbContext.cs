using MVCMultiLayer.Interfaces.DAL.Context;
using System.Data.Entity;

namespace $safeprojectname$.Context
{
    public class GeneralDbContext : DbContext, IDbContext
    {
        public GeneralDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
