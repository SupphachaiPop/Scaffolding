using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.Data
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region [Private Members]
        private DBEntities _dbContext;
        private DbSet<T> _dbSet;

        private EntityState _modifiedState;
        #endregion [Private Members]

        #region [Constructor]
        protected RepositoryBase(DBEntities dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = this._dbContext.Set<T>();

            this._modifiedState = EntityState.Modified;
        }
        #endregion [Constructor]

        #region [Implement]

        #region [Get]
        public T Get(Expression<Func<T, bool>> where)
        {
            return this._dbSet.Where(where).FirstOrDefault<T>();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await this._dbSet.Where(where).FirstOrDefaultAsync<T>();
        }
        #endregion [Get]

        #region [GetMany]
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return this._dbSet.Where(where).ToList();
        }

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where)
        {
            return await this._dbSet.Where(where).ToListAsync();
        }
        #endregion [GetMany]

        #region [GetAll]
        public virtual IEnumerable<T> GetAll()
        {
            return this._dbSet.ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._dbSet.ToListAsync();
        }
        #endregion [GetAll]

        #region [Add]
        public virtual void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        public virtual void Add(IEnumerable<T> entityList)
        {
            foreach (T entity in entityList)
            {
                this._dbSet.Add(entity);
            }
        }
        #endregion [Add]

        #region [Update]
        public virtual void Update(T entity)
        {
            this._dbSet.Attach(entity);
            this._dbContext.Entry(entity).State = this._modifiedState;
        }

        public virtual void Update(T entity, params Expression<Func<T, object>>[] properties)
        {
            this._dbContext.Entry(entity).State = this._modifiedState;
            foreach (var selector in properties)
            {
                this._dbContext.Entry(entity).Property(selector).IsModified = true;
            }
        }
        #endregion [Update]

        #region [Delete]
        public virtual void Delete(T entity)
        {
            this._dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = this._dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                this._dbSet.Remove(obj);
        }
        #endregion [Delete]

        #region [Utility]
        public bool Any(Expression<Func<T, bool>> where)
        {
            return this._dbSet.Any(where);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return await this._dbSet.AnyAsync(where);
        }

        public virtual int GetCount(Expression<Func<T, bool>> where)
        {
            return this._dbSet.Where(where).Count();
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> where)
        {
            return await this._dbSet.Where(where).CountAsync();
        }

        public virtual int GetMax(Expression<Func<T, int>> where)
        {
            return this._dbSet.Max(where);
        }

        public virtual async Task<int> GetMaxAsync(Expression<Func<T, int>> where)
        {
            return await this._dbSet.MaxAsync(where);
        }

        public virtual string GetMax(Expression<Func<T, string>> where)
        {
            return this._dbSet.Max(where);
        }

        public virtual async Task<string> GetMaxAsync(Expression<Func<T, string>> where)
        {
            return await this._dbSet.MaxAsync(where);
        }

        public virtual string GetMax(Expression<Func<T, bool>> where, Expression<Func<T, string>> col)
        {
            return this._dbSet.Where(where).Max(col);
        }

        public virtual async Task<string> GetMaxAsync(Expression<Func<T, bool>> where, Expression<Func<T, string>> col)
        {
            return await this._dbSet.Where(where).MaxAsync(col);
        }
        #endregion [Utility]

        #endregion [Implement]

        //#region [Protected: Stored procedure]
        //protected virtual IEnumerable<T2> ExcuteStoredProcedure<T2>(Dictionary<string, object> spParams = null) where T2 : class
        //{
        //    return this._ExcuteStoredProcedure<T2>(spParams: spParams).ToList();
        //}
        //protected virtual async Task<IEnumerable<T2>> ExcuteStoredProcedureAsync<T2>(Dictionary<string, object> spParams = null) where T2 : class
        //{
        //    return await this._ExcuteStoredProcedure<T2>(spParams: spParams).ToListAsync();
        //}
        //#region [Private Excute Logic]
        //private IQueryable<T2> _ExcuteStoredProcedure<T2>(Dictionary<string, object> spParams = null) where T2 : class
        //{
        //    var spName = typeof(T2).Name;
        //    if (spParams != null && spParams.Count() > 0)
        //    {
        //        #region [Prepare: Parameter name]
        //        var selectedParams = spParams.Where(f =>
        //                                      (
        //                                          !(f.Value is string) && f.Value != null
        //                                      ) ||
        //                                      (
        //                                          (f.Value is string) && !string.IsNullOrEmpty(((string)f.Value))
        //                                      ));
        //        spName = spName + " @" + string.Join(", @", selectedParams.Select(s => s.Key + "=@" + s.Key).ToArray());
        //        #endregion [Prepare: Parameter name]
        //        #region [Split & Merge: mappingParams.Value by Microsoft.Data.SqlClient.SqlParameter]
        //        var paramAssignedType = selectedParams
        //                                .Where(f => f.Value is Microsoft.Data.SqlClient.SqlParameter)
        //                                .Select(s => (Microsoft.Data.SqlClient.SqlParameter  Microsoft)s.Value);
        //        var paramUnassignedType = selectedParams
        //                                  .Where(f => !(f.Value is Microsoft.Data.SqlClient.SqlParameter))
        //                                  .Select(s =>
        //                                  new Microsoft.Data.SqlClient.SqlParameter(s.Key,
        //                                      (
        //                                          (
        //                                              !(s.Value is string) && s.Value == null
        //                                          ) ||
        //                                          (
        //                                              (s.Value is string) && string.IsNullOrEmpty(((string)s.Value))
        //                                          )
        //                                      ) ? DBNull.Value : s.Value
        //                                  ));
        //        var sqlParams = paramAssignedType.Concat(paramUnassignedType);
        //        #endregion [Split & Merge: mappingParams.Value by Microsoft.Data.SqlClient.SqlParameter]
        //        return this._dbContext.Set<T2>().FromSqlRaw($"EXEC dbo.{spName};", sqlParams.ToArray());
        //    }
        //    else
        //    {
        //        return this._dbContext.Set<T2>().FromSqlRaw($"EXEC dbo.{spName};");
        //    }
        //}
        //#endregion [Private Excute Logic]
        //#endregion [Protected: Stored procedure]
    }
}