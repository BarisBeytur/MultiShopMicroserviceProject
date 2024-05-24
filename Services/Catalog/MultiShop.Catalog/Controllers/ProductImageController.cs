using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {

        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _productImageService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("ProductImagesByProductId")]
        public async Task<IActionResult> ProductImagesByProductId(string id)
        {
            var categories = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var productImage = await _productImageService.GetByIdAsync(id);
            return Ok(productImage);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductImageDto productImageDto)
        {
            await _productImageService.CreateAsync(productImageDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductImageDto productImageDto)
        {
            await _productImageService.UpdateAsync(productImageDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productImageService.DeleteAsync(id);
            return Ok();
        }

    }
}
