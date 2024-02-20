using MB.ApplicationContract.Article;
using MB.ApplicationContract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleManagementController : Controller
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public ArticleManagementController(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public IActionResult List()
        {
            var articleViewModels = _articleApplication.GetList();
            return View(articleViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories =
                new SelectList(_articleCategoryApplication.GetAll().Where(x => x.IsDeleted == false), "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateArticle createArticle)
        {
            if (ModelState.IsValid)
            {
                _articleApplication.Create(createArticle);
                return RedirectToAction("List");
            }
            ViewBag.Categories =
                new SelectList(_articleCategoryApplication.GetAll().Where(x => x.IsDeleted == false), "Id", "Title");

            return View(createArticle);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories =
                new SelectList(_articleCategoryApplication.GetAll().Where(x => x.IsDeleted == false), "Id", "Title");
            var editArticle = _articleApplication.GetById(id);
            return View(editArticle);
        }

        [HttpPost]
        public IActionResult Edit(EditArticle editArticle)
        {
            if (ModelState.IsValid)
            {
                _articleApplication.Edit(editArticle);
                return RedirectToAction("List");
            }
            ViewBag.Categories =
                new SelectList(_articleCategoryApplication.GetAll().Where(x => x.IsDeleted == false), "Id", "Title");
            return View(editArticle);
        }
        [HttpPost]
        public IActionResult Activate(int id)
        {
            _articleApplication.Activated(id);
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            _articleApplication.Remove(id);
            return RedirectToAction("List");
        }
    }
}
