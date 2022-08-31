using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Service;

namespace NLayer.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("/GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _service.GetAllAsyncTask();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        
        [HttpGet("/GetByIdProdcut")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var product = await _service.GetByIdAsyncTask(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost("/CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            var product = await _service.AddAsyncTask(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201,productsDto));
        }

        [HttpPut("/UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto productUpdateDto)
        {
            await _service.UpdateAsyncTask(_mapper.Map<Product>(productUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("/DeleteByIdProduct")]
        public async Task<IActionResult> DeleteByIdProduct(int id)
        {
            var product = await _service.GetByIdAsyncTask(id);
            await _service.RemoveAsyncTask(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }


    }
}
