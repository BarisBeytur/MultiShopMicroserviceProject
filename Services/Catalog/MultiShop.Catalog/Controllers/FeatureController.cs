using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Feature;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _FeatureService;

        public FeatureController(IFeatureService FeatureService)
        {
            _FeatureService = FeatureService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _FeatureService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Feature = await _FeatureService.GetByIdAsync(id);
            return Ok(Feature);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateFeatureDto FeatureDto)
        {
            await _FeatureService.CreateAsync(FeatureDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateFeatureDto FeatureDto)
        {
            await _FeatureService.UpdateAsync(FeatureDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _FeatureService.DeleteAsync(id);
            return Ok();
        }
    }
}
