using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;

namespace NLayer.Caching
{
    public class ProductServiceWithCaching : IProductService
    {
        private const string CacheProductKey = "productsCache";
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public ProductServiceWithCaching(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache, IProductRepository productRepository)
        {
            
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _productRepository = productRepository;

            if (!_memoryCache.TryGetValue(CacheProductKey,out _))
            {
                _memoryCache.Set(CacheProductKey, _productRepository.GetProductsWithCategory().Result);
            }
        }

        public Task<Product> GetByIdAsyncTask(int id)
        {
            var product = _memoryCache.Get<List<Product>>(CacheProductKey).FirstOrDefault(x => x.Id == id);
            if (product is null)
            {
                throw new NotFoundException($"{typeof(Product).Name}({id}) not found");
            }

            return Task.FromResult(product);
        }

        public Task<IEnumerable<Product>> GetAllAsyncTask()
        {
            var products = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey);
            return Task.FromResult(products);
        }

        public IQueryable<Product> WhereQueryable(Expression<Func<Product, bool>> expression)
        {
            return _memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }

        public Task<bool> AnyAsyncTask(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> AddAsyncTask(Product entity)
        {
            await _productRepository.AddAsyncTask(entity);
            await _unitOfWork.CommitAsyncTask();
            await CacheProductsAsync();
            return entity;

        }

        public async Task<IEnumerable<Product>> AddRangeAsyncTask(IEnumerable<Product> entities)
        {
            await _productRepository.AddRangeAsyncTask(entities);
            await _unitOfWork.CommitAsyncTask();
            await CacheProductsAsync();
            return entities;
        }

        public async Task UpdateAsyncTask(Product entity)
        {
            _productRepository.Update(entity);
            await _unitOfWork.CommitAsyncTask();
            await CacheProductsAsync();
        }

        public async Task RemoveAsyncTask(Product entity)
        {
            _productRepository.Remove(entity);
            await _unitOfWork.CommitAsyncTask();
            await CacheProductsAsync();

        }

        public async Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            _productRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsyncTask();
            await CacheProductsAsync();

        }

        public Task<CustomResponseDto<List<ProductsWithCategoryDto>>> GetProductsWithCategory()
        {

            var products = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey);
            var productsWithCategoryDto = _mapper.Map<List<ProductsWithCategoryDto>>(products);
            return Task.FromResult(CustomResponseDto<List<ProductsWithCategoryDto>>.Success(200, productsWithCategoryDto));
        }

        public async Task CacheProductsAsync()
        {
            _memoryCache.Set(CacheProductKey, await _productRepository.GetAllAsyncQueryable().ToListAsync());
        }
    }
}
