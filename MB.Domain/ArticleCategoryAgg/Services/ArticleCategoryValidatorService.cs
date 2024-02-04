using MB.Domain.ArticleCategoryAgg.Exception;

namespace MB.Domain.ArticleCategoryAgg.Services;

public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
{
    private readonly IArticleCategoryRepository _repository;

    public ArticleCategoryValidatorService(IArticleCategoryRepository repository)
    {
        _repository = repository;
    }

    public void CheckDuplicated(string title)
    {
        if (_repository.Exists(title))
        {
            throw new DuplicatedMessageException("this Record is Exists on Database");
        }
    }
}