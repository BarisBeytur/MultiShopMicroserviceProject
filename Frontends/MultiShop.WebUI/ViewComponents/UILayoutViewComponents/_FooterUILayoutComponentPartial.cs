using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Constants.FooterConstants;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.Description = FooterConstants.Description;
            ViewBag.Phone = FooterConstants.Phone;
            ViewBag.Email = FooterConstants.Email;
            ViewBag.Address = FooterConstants.Address;
            return View();
        }
    }
}
