using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ArticleCategory(string title/*IArticleCategoryValidatorService checkDuplicated*/)
        {
            CheckEmptyTitle(title);
            //checkDuplicated.CheckDuplicated(title);

            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }

        private void CheckEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException();
            }
        }
        public void Rename(string title, IArticleCategoryValidatorService checkDuplicated)
        {
            CheckEmptyTitle(title);
            checkDuplicated.CheckDuplicated(title);

            Title = title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
