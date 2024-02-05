using MB.ApplicationContract.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void Create(Article entity);
        Article GetById(int id);
        void Save();
    }
}
