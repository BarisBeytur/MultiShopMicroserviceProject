using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Entities;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {

        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _discountService.GetAllCouponsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _discountService.GetCouponByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCouponDto coupon)
        {
            await _discountService.CreateCouponAsync(coupon);
            return Ok("Kupon başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCouponDto coupon)
        {
            await _discountService.UpdateCouponAsync(coupon);
            return Ok("Kupon başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("Kupon başarıyla silindi");
        }

    }
}
