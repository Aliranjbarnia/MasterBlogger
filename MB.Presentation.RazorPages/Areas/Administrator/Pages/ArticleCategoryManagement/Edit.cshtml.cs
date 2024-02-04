using MB.ApplicationContract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPages.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategory;

        public EditModel(IArticleCategoryApplication articleCategory)
        {
            _articleCategory = articleCategory;
        }

        [BindProperty]
        public EditArticleCategory ArticleCategory { get; set; }
        
        public void OnGet(int id)
        {
            ArticleCategory = _articleCategory.GetCategoryById(id);
        }

        public IActionResult OnPost()
        {
            _articleCategory.Rename(ArticleCategory);
            return RedirectToPage("./List");
        }
    }
}
