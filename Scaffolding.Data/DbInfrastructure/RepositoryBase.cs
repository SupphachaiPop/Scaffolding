using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Scaffolding.Data.DbInfrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);
        void Add(IEnumerable<T> entityList);

        // Marks an entity as modified
        void Update(T entity);
        void Update(IEnumerable<T> entityList);
        //void Update(T entity, Expression<Func<T, object>>[] properties);
        void Update(T entity, params Expression<Func<T, object>>[] properties);

        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);

        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);

        // Gets all entities of type T
        IEnumerable<T> GetAll();

        // Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        bool Any(Expression<Func<T, bool>> where);

        int GetMax(Expression<Func<T, int>> where);

        string GetMax(Expression<Func<T, string>> where);

        string GetMax(Expression<Func<T, bool>> where, Expression<Func<T, string>> col);

        DateTime? GetDateWithOutTime(DateTime d);
    }

    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties

        private BNNPROEntities dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected BNNPROEntities DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        #endregion

        #region Constructor

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #endregion

        #region Implementation

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Add(IEnumerable<T> entityList)
        {
            foreach (T entity in entityList)
            {
                dbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        
        public virtual void Update(T entity, params Expression<Func<T, object>>[] properties)
        {
            dataContext.Entry(entity).State = EntityState.Unchanged;
            foreach (var selector in properties)
            {
                dataContext.Entry(entity).Property(selector).IsModified = true;
            }
        }

        public virtual void Update(IEnumerable<T> entityList)
        {
            foreach (T entity in entityList)
            {
                dbSet.Attach(entity);
                dataContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return dbSet.Any(where);
        }

        public virtual int GetMax(Expression<Func<T, int>> where)
        {
            return dbSet.Max(where);
        }

        public virtual string GetMax(Expression<Func<T, string>> where)
        {
            return dbSet.Max(where);
        }

        public virtual string GetMax(Expression<Func<T, bool>> where, Expression<Func<T, string>> col)
        {
            return dbSet.Where(where).Max(col);
        }

        public DateTime? GetDateWithOutTime(DateTime d)
        {
            return DbFunctions.TruncateTime(d);
        }

        #endregion
    }
}
