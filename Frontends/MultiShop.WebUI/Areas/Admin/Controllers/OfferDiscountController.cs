using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public OfferDiscountController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageHeader = "İndirim Teklifleri İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklifleri Listesi";

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/OfferDiscount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData.Result);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.PageHeader = "İndirim Teklifleri İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklifleri Ekleme";

            return View();
        }

        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var client = _clientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createOfferDiscountDto);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7070/api/OfferDiscount", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }

            return View();
        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var client = _clientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/OfferDiscount/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }

            return View();
        }


        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.PageHeader = "İndirim Teklifleri İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklifleri Güncelleme";

            var client = _clientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7070/api/OfferDiscount/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData.Result);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id, UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var client = _clientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateOfferDiscountDto);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7070/api/OfferDiscount/", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }

            return View();
        }
    }
}
