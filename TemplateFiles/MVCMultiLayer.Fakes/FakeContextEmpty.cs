using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace $safeprojectname$
{
    public class FakeContextEmpty : FakeContextBase
    {       
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
