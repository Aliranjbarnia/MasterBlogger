using MB.ApplicationContract.Article;
using MB.ApplicationContract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.RazorPages.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditArticle Article { get; set; }
        public List<SelectListItem> ArticleCategories { get; set; }

        private readonly IArticleApplication _article;
        private readonly IArticleCategoryApplication _articleCategory;
        public EditModel(IArticleApplication article, IArticleCategoryApplication articleCategory)
        {
            _article = article;
            _articleCategory = articleCategory;
        }

        public void OnGet(int id)
        {
            Article = _article.GetById(id);
            ArticleCategories = _articleCategory.GetAll().Where(x=>x.IsDeleted == false).Select(x => new SelectListItem(x.Title, x.Id.ToString()))
                .ToList();
        }

        public IActionResult OnPost(EditArticle command)
        {
            _article.Edit(command);
            return RedirectToPage("./List");
        }
    }
}
