using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {

        private readonly IHttpClientFactory _clientFactory;

        public ProductDetailController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.PageHeader = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Açıklaması";
            ViewBag.v3 = "Ürün Açıklaması Güncelleme";

            var client = _clientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductDetail/GetProductDetailByProductId?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData.Result);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var client = _clientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7070/api/ProductDetail/", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }

            return View();
        }
    }
}
