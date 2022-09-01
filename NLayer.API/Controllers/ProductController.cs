using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Service;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("ProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            var productWithCategory = await _productService.GetProductsWithCategory();
            return CreateActionResult(productWithCategory);
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsyncTask();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetByIdAsyncTask(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            var product = await _productService.AddAsyncTask(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201,productsDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> ProductUpdate(ProductUpdateDto productUpdateDto)
        {
            await _productService.UpdateAsyncTask(_mapper.Map<Product>(productUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var product = await _productService.GetByIdAsyncTask(id);
            await _productService.RemoveAsyncTask(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        


    }
}
