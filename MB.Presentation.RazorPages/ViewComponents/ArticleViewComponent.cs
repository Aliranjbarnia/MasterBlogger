using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;

namespace MB.Presentation.RazorPages.ViewComponents
{
    public class ArticleViewComponent :ViewComponent
    {
        private readonly IArticleQuery _articleQuery;

        public ArticleViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {
            var articleQueryViews = _articleQuery.GetArticles();
            return View(articleQueryViews);
        }
    }
}
