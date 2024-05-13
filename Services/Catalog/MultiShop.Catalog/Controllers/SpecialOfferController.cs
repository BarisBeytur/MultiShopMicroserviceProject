using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {

        private readonly ISpecialOfferService _SpecialOfferService;

        public SpecialOfferController(ISpecialOfferService SpecialOfferService)
        {
            _SpecialOfferService = SpecialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _SpecialOfferService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var SpecialOffer = await _SpecialOfferService.GetByIdAsync(id);
            return Ok(SpecialOffer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSpecialOfferDto SpecialOfferDto)
        {
            await _SpecialOfferService.CreateAsync(SpecialOfferDto);
            return Ok("Ekleme basarili.");
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateSpecialOfferDto SpecialOfferDto)
        {
            await _SpecialOfferService.UpdateAsync(SpecialOfferDto);
            return Ok("Guncelleme basarili.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _SpecialOfferService.DeleteAsync(id);
            return Ok("Silme basarili.");
        }
    }
}
