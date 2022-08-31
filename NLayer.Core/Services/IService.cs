using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Service
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsyncTask(int id);
        Task<IEnumerable<T>> GetAllAsyncTask();
        IQueryable<T> WhereQueryable(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsyncTask(Expression<Func<T, bool>> expression);
        Task<T> AddAsyncTask(T entity);
        Task<IEnumerable<T>> AddRangeAsyncTask(IEnumerable<T> entities);
        Task UpdateAsyncTask(T entity);
        Task RemoveAsyncTask(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
