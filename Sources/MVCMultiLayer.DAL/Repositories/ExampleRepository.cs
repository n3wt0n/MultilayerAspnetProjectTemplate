using MVCMultiLayer.DAL.Entities;
using MVCMultiLayer.DAL.GenericRepository;
using MVCMultiLayer.Interfaces.DAL.Context;

namespace MVCMultiLayer.DAL.Repositories
{
    public class ExampleRepository : Repository<Example>
    {
        public ExampleRepository(IDbContext context)
            : base(context)
        {

        }
    }
}
