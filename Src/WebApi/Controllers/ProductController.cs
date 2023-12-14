using Microsoft.AspNetCore.Mvc;
using UseCase.Dto;
using UseCase.Interface;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            await _productService.AddProduct(dto);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto dto)
        {
            await _productService.UpdateProduct(dto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _productService.Get(Id);
            if (result == null) return NoContent();
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IEnumerable<ProductDto>> GetList()
        {
            return await _productService.GetProducts();
        }
    }
}
