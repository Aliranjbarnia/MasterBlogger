using MB.ApplicationContract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPages.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class CreateModel : PageModel
    {
        public CreateCategory CreateCategory { get; set; }
        private readonly IArticleCategoryApplication _articleCategory;

        public CreateModel(IArticleCategoryApplication articleCategory)
        {
            _articleCategory = articleCategory;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(CreateCategory entity)
        {
            _articleCategory.Create(entity);
            return RedirectToPage("./List");
        }
    }
}
