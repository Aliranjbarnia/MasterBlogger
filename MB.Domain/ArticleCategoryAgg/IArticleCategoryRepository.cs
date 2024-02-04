namespace MB.Domain.ArticleCategoryAgg;

public interface IArticleCategoryRepository
{
    List<ArticleCategory> GetAll();
    void Create(ArticleCategory entity);
    ArticleCategory GetById(int id);
    void Save();
    bool Exists(string title);
}