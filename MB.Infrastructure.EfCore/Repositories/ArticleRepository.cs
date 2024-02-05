using System.Globalization;
using MB.ApplicationContract.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleContext _context;

        public ArticleRepository(ArticleContext context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x=>x.ArticleCategory).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.CurrentCulture),
                IsDeleted = x.IsDeleted,
                ArticleCategory = x.ArticleCategory.Title
            }).OrderByDescending(x => x.Id).ToList();
        }

        public void Create(Article entity)
        {
            _context.Articles.Add(entity);
        }

        public Article GetById(int id)
        {
            return _context.Articles.FirstOrDefault(x=>x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
