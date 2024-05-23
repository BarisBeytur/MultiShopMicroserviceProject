using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Brand;
using MultiShop.Catalog.Services.BrandService;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _BrandService;

        public BrandController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _BrandService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Brand = await _BrandService.GetByIdAsync(id);
            return Ok(Brand);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBrandDto BrandDto)
        {
            await _BrandService.CreateAsync(BrandDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateBrandDto BrandDto)
        {
            await _BrandService.UpdateAsync(BrandDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _BrandService.DeleteAsync(id);
            return Ok();
        }

    }
}
