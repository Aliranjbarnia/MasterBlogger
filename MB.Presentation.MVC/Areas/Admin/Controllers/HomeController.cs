using Microsoft.AspNetCore.Mvc;

namespace MB.Presentation.MVC.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult IndexAdmin()
        {
            return View();
        }
    }
}
