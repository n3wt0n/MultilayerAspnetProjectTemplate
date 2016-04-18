using MVCMultiLayer.DAL.Entities;
using MVCMultiLayer.Interfaces.DAL.Context;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCMultiLayer.Fakes
{
    public class FakeContext : DbContext, IDbContext
    {
        #region Sets
        public DbSet<Example> Examples { get; set; }       
        #endregion

        public FakeContext()
            : base("FakeContextDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
