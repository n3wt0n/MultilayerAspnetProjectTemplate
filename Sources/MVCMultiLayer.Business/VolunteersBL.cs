using MVCMultiLayer.Interfaces.DAL.Repository;
using MVCMultiLayer.Business.Entities;
using System.Collections;

namespace MVCMultiLayer.Business
{
    public class VolunteersBL : BaseBL
    {
        IRepository<DAL.Entities.Example> repo;

        public VolunteersBL(IRepository<DAL.Entities.Example> repo)
        {
            this.repo = repo;
        }
        
    }
}
