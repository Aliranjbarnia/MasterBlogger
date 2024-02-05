using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPages.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        [BindProperty] public ArticleQueryView Article { get; set; }
        private readonly IArticleQuery _articleQuery;

        public ArticleDetailsModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet(int id)
        {
            Article = _articleQuery.GetArticle(id);
        }
    }
}
