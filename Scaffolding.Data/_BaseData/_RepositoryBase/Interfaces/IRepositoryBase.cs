using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.Data
{
    public interface IRepositoryBase<T> where T : class
    {
        // Get
        T Get(Expression<Func<T, bool>> where);
        Task<T> GetAsync(Expression<Func<T, bool>> where);

        // GetMany
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);

        // GetAll
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        // Add
        void Add(T entity);
        void Add(IEnumerable<T> entityList);

        // Update
        void Update(T entity);
        void Update(T entity, params Expression<Func<T, object>>[] properties);

        // Delete
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);

        // Utility
        bool Any(Expression<Func<T, bool>> where);
        Task<bool> AnyAsync(Expression<Func<T, bool>> where);
        int GetCount(Expression<Func<T, bool>> where);
        Task<int> GetCountAsync(Expression<Func<T, bool>> where);
        int GetMax(Expression<Func<T, int>> where);
        Task<int> GetMaxAsync(Expression<Func<T, int>> where);
        string GetMax(Expression<Func<T, string>> where);
        Task<string> GetMaxAsync(Expression<Func<T, string>> where);
        string GetMax(Expression<Func<T, bool>> where, Expression<Func<T, string>> col);
        Task<string> GetMaxAsync(Expression<Func<T, bool>> where, Expression<Func<T, string>> col);
    }
}
