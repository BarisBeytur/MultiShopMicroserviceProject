using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {

        private readonly IProductDetailService _productDetailService;


        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productDetails = await _productDetailService.GetAllAsync();
            return Ok(productDetails);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var productDetail = await _productDetailService.GetByIdAsync(id);
            return Ok(productDetail);
        }

        [HttpGet]
        [Route("GetProductDetailByProductId")]
        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var productDetail = await _productDetailService.GetProductDetailByProductId(id);
            return Ok(productDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductDetailDto productDetailDto)
        {
            await _productDetailService.CreateAsync(productDetailDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductDetailDto productDetailDto)
        {
            await _productDetailService.UpdateAsync(productDetailDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productDetailService.DeleteAsync(id);
            return Ok();
        }


    }
}
