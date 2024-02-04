namespace MB.ApplicationContract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> GetAll();
        void Create(CreateCategory command);
        void Rename(EditArticleCategory command);
        EditArticleCategory GetCategoryById(int id);
        void Remove(int id);
        void Activate(int id);
    }
}
