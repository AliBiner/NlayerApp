using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("SingleCategoryByIdProducts")]
        public async Task<IActionResult> GetSingleCategoryByIdProductsAsync(int categoryId)
        {
            var categorywithproducts = await _categoryService.GetSingleCategoryByIdProductsAsync(categoryId);
            return CreateActionResult(categorywithproducts);
        }
    }
}
