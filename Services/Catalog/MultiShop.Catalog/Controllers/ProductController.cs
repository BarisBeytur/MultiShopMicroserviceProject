using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductDto productDto)
        {
            await _productService.CreateAsync(productDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductDto productDto)
        {
            await _productService.UpdateAsync(productDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }


    }
}
