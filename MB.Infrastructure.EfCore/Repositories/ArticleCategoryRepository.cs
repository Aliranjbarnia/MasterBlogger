using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly ArticleContext _context;

        public ArticleCategoryRepository(ArticleContext context)
        {
            _context = context;
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.OrderByDescending(x=>x.Id).ToList();
        }

        public void Create(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
        }

        public ArticleCategory GetById(int id)
        {
            return _context.ArticleCategories.FirstOrDefault(x=>x.Id == id);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exists(string title)
        {
            return _context.ArticleCategories.Any(x=>x.Title == title);
        }
    }
}
