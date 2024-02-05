using System.Globalization;
using MB.ApplicationContract.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategory;
        private readonly IArticleCategoryValidatorService _validatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategory, IArticleCategoryValidatorService validatorService)
        {
            _articleCategory = articleCategory;
            _validatorService = validatorService;
        }

        public List<ArticleCategoryViewModel> GetAll()
        {
            return _articleCategory.GetAll().Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                IsDeleted = x.IsDeleted

            }).ToList();
        }

        public void Create(CreateCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title, _validatorService);
            _articleCategory.Create(articleCategory);
            _articleCategory.Save();
        }
        public void Rename(EditArticleCategory command)
        {
            var articleCategory = _articleCategory.GetById(command.Id);
            articleCategory.Rename(command.Title, _validatorService);
            _articleCategory.Save();
        }

        public EditArticleCategory GetCategoryById(int id)
        {
            var category = _articleCategory.GetById(id);
            return new EditArticleCategory
            {
                Id = category.Id,
                Title = category.Title
            };
        }

        public void Remove(int id)
        {
            var articleRemove = _articleCategory.GetById(id);
            articleRemove.Remove();
            _articleCategory.Save();
        }

        public void Activate(int id)
        {
            var articleActivate = _articleCategory.GetById(id);
            articleActivate.Activate();
            _articleCategory.Save();
        }
    }
}
