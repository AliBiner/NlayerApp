using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Service;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("v1/api/[controller]/")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IService<Product> service, IProductService productService)
        {
            _mapper = mapper;
            _service = service;
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
            var products = await _service.GetAllAsyncTask();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetByIdAsyncTask(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            var product = await _service.AddAsyncTask(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201,productsDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> ProductUpdate(ProductUpdateDto productUpdateDto)
        {
            await _service.UpdateAsyncTask(_mapper.Map<Product>(productUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var product = await _service.GetByIdAsyncTask(id);
            await _service.RemoveAsyncTask(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        


    }
}
