using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repository
{
    public interface IGenericRepository<T> where  T : class
    {
        Task<T> GetByIdAsyncTask(int id);
        IQueryable<T> GetAllAsyncQueryable();
        IQueryable<T> WhereQueryable(Expression<Func<T,bool>> expression);
        Task<bool> AnyAsyncTask(Expression<Func<T, bool>> expression);
        Task AddAsyncTask(T entity);
        Task AddRangeAsyncTask(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
