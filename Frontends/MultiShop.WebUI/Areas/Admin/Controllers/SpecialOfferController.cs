using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class SpecialOfferController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
