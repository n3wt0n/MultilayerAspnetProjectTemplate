using $safeprojectname$.DAL.Context;
using System.Linq;

namespace $safeprojectname$.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(bool alsoDeleted = false);

        IQueryable<T> GetPaged(int pageIndex, int pageSize, bool alsoDeleted = false);

        IQueryable<T> GetDeleted();

        T GetById(int id);

        T GetByCompositeId(int id, int galleryId);

        void Add(T entity);
        
        void Update(T entity);
        
        void Delete(T entity);
        
        void Delete(int id);

        void DeleteCompositeId(int id, int galleryId);

        IDbContext GetContext();
    }   
}
