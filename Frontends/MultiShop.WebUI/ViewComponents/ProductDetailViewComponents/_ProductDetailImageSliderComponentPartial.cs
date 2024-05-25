﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial: ViewComponent
    {

        private readonly IHttpClientFactory _clientFactory;

        public _ProductDetailImageSliderComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductImage/ProductImagesByProductId?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData.Result);
                return View(values);
            }

            return View();
        }
    }
}
