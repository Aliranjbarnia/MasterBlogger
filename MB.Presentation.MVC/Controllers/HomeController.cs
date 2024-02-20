using MB.Infrastructure.Query;
using MB.Presentation.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MB.Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleQuery _articleQuery;

        public HomeController(ILogger<HomeController> logger, IArticleQuery articleQuery)
        {
            _logger = logger;
            _articleQuery = articleQuery;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetDetails(int id)
        {
            var articleQueryView = _articleQuery.GetArticle(id);
            return View(articleQueryView);
        }


        public IActionResult Empity()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
