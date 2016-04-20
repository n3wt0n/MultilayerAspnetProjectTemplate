using MVCMultiLayer.DAL.Entities;
using MVCMultiLayer.Interfaces.DAL.Context;
using System.Data.Entity;

namespace $safeprojectname$
{
    public class FakeContextBase : DbContext, IDbContext
    {
        public FakeContextBase(string fakeContextName)
            : base(fakeContextName)
        {

        }

        //SETS
        public DbSet<Example> Examples { get; set; }        
    }
}
