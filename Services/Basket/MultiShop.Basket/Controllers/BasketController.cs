using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {

        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var user = User.Claims;
            
            var userId = _loginService.GetUserId;
            var basket = await _basketService.GetBasketAsync(userId);

            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;

            await _basketService.SaveBasketAsync(basketTotalDto);

            return Ok("Sepet basariyla kaydedildi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var userId = _loginService.GetUserId;

            await _basketService.DeleteBasketAsync(userId);

            return Ok("Sepet basariyla silindi");
        }


    }
}
