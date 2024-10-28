using Microsoft.AspNetCore.Mvc;

namespace UILayer.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class Panel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
