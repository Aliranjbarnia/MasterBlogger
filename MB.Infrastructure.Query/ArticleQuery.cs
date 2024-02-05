using System.Globalization;
using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly ArticleContext _context;

        public ArticleQuery(ArticleContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Select(x =>
                    new ArticleQueryView
                    {
                        Id = x.Id,
                        Title = x.Title,
                        ArticleCategory = x.ArticleCategory.Title,
                        CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                        ShortDescription = x.ShortDescription,
                        Image = x.Image,
                    }).ToList();
        }

        public ArticleQueryView GetArticle(int id)
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                Content = x.Content
            }).FirstOrDefault(x => x.Id == id);
        }

        //private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        //{
        //    return comments.Select(comment => new CommentQueryView
        //    {
        //        Name = comment.Name, CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
        //        Message = comment.Message
        //    }).ToList();
        //}
    }
}