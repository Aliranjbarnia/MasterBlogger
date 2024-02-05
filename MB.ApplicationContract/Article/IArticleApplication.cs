namespace MB.ApplicationContract.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        EditArticle GetById(int id);
    }

    public class EditArticle : CreateArticle
    {
        public int Id { get; set; }
    }
}
