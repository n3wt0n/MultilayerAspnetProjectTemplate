using MVCMultiLayer.DAL.Entities;
using MVCMultiLayer.DAL.GenericRepository;
using MVCMultiLayer.Interfaces.DAL.Context;

namespace MVCMultiLayer.DAL.Repositories
{
    public class VolunteerRepository : Repository<Example>
    {
        public VolunteerRepository(IDbContext context)
            : base(context)
        {

        }
    }
}
