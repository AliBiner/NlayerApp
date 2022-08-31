using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repository;

namespace NLayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        public async Task<T> GetByIdAsyncTask(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> GetAllAsyncQueryable()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> WhereQueryable(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
        
        public async Task<bool> AnyAsyncTask(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task AddAsyncTask(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsyncTask(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
    
}
