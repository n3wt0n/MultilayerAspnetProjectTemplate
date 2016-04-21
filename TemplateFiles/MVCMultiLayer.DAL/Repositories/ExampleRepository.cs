using $safeprojectname$.Entities;
using $safeprojectname$.GenericRepository;
using MVCMultiLayer.Interfaces.DAL.Context;

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
