using MB.ApplicationContract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;

namespace MB.Presentation.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleCategoryManagementController : Controller
    {
        private readonly IArticleCategoryApplication _articleCategory;

        public ArticleCategoryManagementController(IArticleCategoryApplication articleCategory)
        {
            _articleCategory = articleCategory;
        }

        public IActionResult List()
        {
            var articleCategoryViewModels = _articleCategory.GetAll();
            return View(articleCategoryViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategory create)
        {
            if (ModelState.IsValid)
            {
                _articleCategory.Create(create);
                return RedirectToAction("List");
            }

            return View(create);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editArticleCategory = _articleCategory.GetCategoryById(id);

            return View(editArticleCategory);
        } 
        [HttpPost]
        public IActionResult Edit(EditArticleCategory editArticleCategory)
        {
            if (ModelState.IsValid)
            {
                _articleCategory.Rename(editArticleCategory);
                return RedirectToAction("List");
            }
            
            return View();
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            _articleCategory.Remove(id);
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Activate(int id)
        {
            _articleCategory.Activate(id);
            return RedirectToAction("List");
        }
    }
}
