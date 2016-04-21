using $saferootprojectname$.DAL.Entities;
using $saferootprojectname$.Interfaces.DAL.Context;
using System;
using System.Web;

namespace $safeprojectname$
{
    public class BaseBL : IDisposable
    {
        protected IDbContext ctx;        

        protected void MarkAsUpdated(BaseEntity bEntity, string username = null)
        {
            bEntity.UserLastChange = username ?? (HttpContext.Current?.User?.Identity?.Name ?? "System");
            bEntity.DateLastChange = DateTime.Now;
        }

        protected void MarkAsDeleted(BaseEntity bEntity, string username = null)
        {
            MarkAsUpdated(bEntity, username);
            bEntity.IsDeleted = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool all)
        {
            if (ctx != null)
                ctx.Dispose();
        }
    }
}
