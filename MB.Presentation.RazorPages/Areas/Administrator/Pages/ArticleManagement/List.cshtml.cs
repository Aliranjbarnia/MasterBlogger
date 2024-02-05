using MB.ApplicationContract.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPages.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _articleApplication;

        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetList();
        }

        public IActionResult OnPostActivate(int id)
        {
            _articleApplication.Activated(id);
            return RedirectToPage("./List");
        }
        public IActionResult OnPostRemove(int id)
        {
            _articleApplication.Remove(id);
            return RedirectToPage("./List");
        }

    }
}
