using MVCMultiLayer.DAL.Entities;
using MVCMultiLayer.Interfaces.DAL.Context;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCMultiLayer.Fakes
{
    public class FakeContextEmpty : DbContext, IDbContext
    {
        #region Sets
        public DbSet<Example> Examples { get; set; }
        #endregion

        public FakeContextEmpty()
            : base("FakeContextEmptyDB")
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
