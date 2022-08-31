using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repository;
using NLayer.Core.Service;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsyncTask(T entity)
        {
            await _repository.AddAsyncTask(entity);
            await _unitOfWork.CommitAsyncTask();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsyncTask(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsyncTask(entities);
            await _unitOfWork.CommitAsyncTask();
            return entities;
        }

        public async Task<bool> AnyAsyncTask(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsyncTask(expression);

        }

        

        public async Task<IEnumerable<T>> GetAllAsyncTask()
        {
            return await _repository.GetAllAsyncQueryable().ToListAsync();
        }

        public async Task<T> GetByIdAsyncTask(int id)
        {
            return await _repository.GetByIdAsyncTask(id);
        }

        public async Task RemoveAsyncTask(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsyncTask();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsyncTask();
        }

        public async Task UpdateAsyncTask(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsyncTask();
        }

        public IQueryable<T> WhereQueryable(Expression<Func<T, bool>> expression)
        {
            return _repository.WhereQueryable(expression);
        }
    }
}
