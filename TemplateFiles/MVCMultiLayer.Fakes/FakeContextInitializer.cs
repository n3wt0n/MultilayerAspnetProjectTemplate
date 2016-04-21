using $saferootprojectname$.DAL.Entities;
using System.Data.Entity;

namespace $safeprojectname$
{
    public class FakeContextInitializer : DropCreateDatabaseAlways<FakeContext>
    {
        protected override void Seed(FakeContext context)
        {
            context.Examples.Add(new Example() { });

            //Insert into context
            context.SaveChanges();
        }
    }


    public class FakeContextEmptyInitializer : DropCreateDatabaseAlways<FakeContextEmpty>
    {
    }
}
