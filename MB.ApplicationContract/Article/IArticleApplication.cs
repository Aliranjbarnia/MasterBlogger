namespace MB.ApplicationContract.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        EditArticle GetById(int id);
        void Remove(int id);
        void Activated(int id);
    }
}
