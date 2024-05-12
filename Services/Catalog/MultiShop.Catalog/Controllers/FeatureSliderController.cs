using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSliderController : ControllerBase
    {
        private readonly IFeatureSliderService _FeatureSliderService;

        public FeatureSliderController(IFeatureSliderService FeatureSliderService)
        {
            _FeatureSliderService = FeatureSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _FeatureSliderService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var FeatureSlider = await _FeatureSliderService.GetByIdAsync(id);
            return Ok(FeatureSlider);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateFeatureSliderDto FeatureSliderDto)
        {
            await _FeatureSliderService.CreateAsync(FeatureSliderDto);
            return Ok("Ekleme başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateFeatureSliderDto FeatureSliderDto)
        {
            await _FeatureSliderService.UpdateAsync(FeatureSliderDto);
            return Ok("Güncelleme başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _FeatureSliderService.DeleteAsync(id);
            return Ok("Silme başarılı");
        }
    }
}
