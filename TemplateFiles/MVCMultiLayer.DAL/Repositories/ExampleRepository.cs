using $safeprojectname$.Entities;
using $safeprojectname$.GenericRepository;
using $saferootprojectname$.Interfaces.DAL.Context;

namespace $safeprojectname$.Repositories
{
    public class ExampleRepository : Repository<Example>
    {
        public ExampleRepository(IDbContext context)
            : base(context)
        {

        }
    }
}
