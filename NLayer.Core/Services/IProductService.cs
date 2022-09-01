using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Repository;
using NLayer.Core.Service;

namespace NLayer.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductsWithCategoryDto>>> GetProductsWithCategory();
    }
}
