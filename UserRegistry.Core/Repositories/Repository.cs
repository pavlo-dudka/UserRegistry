using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace UserRegistry.Core.Repositories
{
    public abstract class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected DbContext DBContext;

        public Repository(DbContext context)
        {
            DBContext = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return DBContext.Set<T>();
        }

        public virtual T GetSingle(int id)
        {
            return DBContext.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            DBContext.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            DBContext.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Modified;
        }

        private bool Exists(int id)
        {
            return GetSingle(id) != null;
        }

        public virtual bool Save()
        {
            try
            {
                DBContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new UpdateException("SaveChanges failed", ex);
            }

            return true;
        }

        public void Dispose()
        {
            DBContext.Dispose();
        }
    }
}
