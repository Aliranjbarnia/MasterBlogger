using MB.ApplicationContract.Article;
using MB.ApplicationContract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.RazorPages.Areas.Administrator.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {
        public List<SelectListItem> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategory;
        private readonly IArticleApplication _article;

        public CreateModel(IArticleCategoryApplication articleCategory, IArticleApplication article)
        {
            _articleCategory = articleCategory;
            _article = article;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategory.GetAll().Select(x=> new SelectListItem(x.Title,x.Id.ToString())).ToList();
        }

        public IActionResult OnPost(CreateArticle command)
        {
            _article.Create(command);
            return RedirectToPage("./List");
        }
    }
}
