using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Caching
{
    public class ProductServiceWithCaching : IProductService
    {
        private const string CacheProductKey = "productsCache";
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public ProductServiceWithCaching(IProductService productService, IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache, IProductRepository productRepository)
        {
            
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _productRepository = productRepository;

            if (!_memoryCache.TryGetValue(CacheProductKey,out _))
            {
                _memoryCache.Set(CacheProductKey, _productRepository.GetAllAsyncQueryable().ToList());
            }
        }

        public Task<Product> GetByIdAsyncTask(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsyncTask()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> WhereQueryable(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsyncTask(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Product> AddAsyncTask(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> AddRangeAsyncTask(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsyncTask(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsyncTask(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<List<ProductsWithCategoryDto>>> GetProductsWithCategory()
        {
            throw new NotImplementedException();
        }
    }
}
