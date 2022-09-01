using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Service;

namespace NLayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdProductsAsync(int categoryId);
    }
}
