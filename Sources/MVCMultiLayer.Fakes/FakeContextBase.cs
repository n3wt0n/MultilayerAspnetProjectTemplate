using MVCMultiLayer.DAL.Entities;
using MVCMultiLayer.Interfaces.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMultiLayer.Fakes
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
