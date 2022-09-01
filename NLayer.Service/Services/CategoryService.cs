using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Repositories;
using NLayer.Core.Repository;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repositories;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }



        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdProductsAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdProductsAsync(categoryId);
            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);
            return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
        }
    }
}
