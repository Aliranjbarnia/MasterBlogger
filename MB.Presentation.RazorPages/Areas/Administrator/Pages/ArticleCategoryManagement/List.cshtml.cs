using MB.ApplicationContract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPages.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategory;

        public ListModel(IArticleCategoryApplication articleCategory)
        {
            _articleCategory = articleCategory;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategory.GetAll();
        }

        public IActionResult OnPostRemove(int id)
        {
            _articleCategory.Remove(id);
            return RedirectToPage("./List");
        }
        public IActionResult OnPostActivate(int id)
        {
            _articleCategory.Activate(id);
            return RedirectToPage("./List");
        }
    }
}
