using $safeprojectname$.Entities;
using $safeprojectname$.GenericRepository;
using MVCMultiLayer.Interfaces.DAL.Context;

namespace $safeprojectname$.Repositories
{
    public class VolunteerRepository : Repository<Example>
    {
        public VolunteerRepository(IDbContext context)
            : base(context)
        {

        }
    }
}
