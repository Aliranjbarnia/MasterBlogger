using MB.ApplicationContract.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ShortDescription, command.Image, command.Content,
                command.ArticleCategoryId);
            _articleRepository.Create(article);
            _articleRepository.Save();
        }

        public void Edit(EditArticle command)
        {
            var articleEdit = _articleRepository.GetById(command.Id);
            articleEdit.Edit(command.Title, command.ShortDescription, command.Image, command.Content,
                command.ArticleCategoryId);
            _articleRepository.Save();

        }

        public EditArticle GetById(int id)
        {
            var article = _articleRepository.GetById(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId
            };
        }
    }
}
