using $safeprojectname$.Entities;
using $saferootprojectname$.Interfaces.DAL.Context;
using $saferootprojectname$.Interfaces.DAL.Repository;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace $safeprojectname$.GenericRepository
{
    /// <summary>
    /// The EF-dependent, generic repository for data access
    /// </summary>
    /// <typeparam name="T">Type of entity for this Repository.</typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public Repository(IDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("Null DbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected IDbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll(bool alsoDeleted = false)
        {
            if (alsoDeleted)
                return DbSet;
            else
                return DbSet.Where(e => e.IsDeleted == false);
        }

        public virtual IQueryable<T> GetPaged(int pageIndex, int pageSize, bool alsoDeleted = false)
        {
            if (pageIndex >= 0 && pageSize > 0)
                if (alsoDeleted)
                    return DbSet.Skip(pageIndex * pageSize).Take(pageSize);
                else
                    return DbSet.Where(e => e.IsDeleted == false).Skip(pageIndex * pageSize).Take(pageSize);
            else
                if (alsoDeleted)
                    return DbSet.Where(e => e.IsDeleted == false);
                else
                    return DbSet;
        }

        public virtual IQueryable<T> GetDeleted()
            => DbSet.Where(e => e.IsDeleted == true);        

        public virtual T GetById(int id)
            => DbSet.Find(id);

        public virtual T GetByCompositeId(int id, int galleryId)
           => DbSet.Find(id, galleryId);

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
            DbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Physical Delete
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Physical Delete
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        /// <summary>
        /// Physical Delete with composite id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="galleryId"></param>
        public virtual void DeleteCompositeId(int id, int galleryId)
        {
            var entity = GetByCompositeId(id, galleryId);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        /// <summary>
        /// returns the Current DbContext
        /// </summary>
        /// <returns></returns>
        public IDbContext GetContext()
            => DbContext;        
    }
}
