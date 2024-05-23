using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountController : ControllerBase
    {

        private readonly IOfferDiscountService _OfferDiscountService;

        public OfferDiscountController(IOfferDiscountService OfferDiscountService)
        {
            _OfferDiscountService = OfferDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _OfferDiscountService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var OfferDiscount = await _OfferDiscountService.GetByIdAsync(id);
            return Ok(OfferDiscount);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOfferDiscountDto OfferDiscountDto)
        {
            await _OfferDiscountService.CreateAsync(OfferDiscountDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateOfferDiscountDto OfferDiscountDto)
        {
            await _OfferDiscountService.UpdateAsync(OfferDiscountDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _OfferDiscountService.DeleteAsync(id);
            return Ok();
        }

    }
}
