using Microsoft.AspNetCore.Mvc;

namespace UILayer.Areas.AdminPanel.AdminPanel
{
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
