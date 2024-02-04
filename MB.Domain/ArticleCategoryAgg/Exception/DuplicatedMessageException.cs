namespace MB.Domain.ArticleCategoryAgg.Exception
{
    public class DuplicatedMessageException: System.Exception
    {
        public DuplicatedMessageException()
        {
        }

        public DuplicatedMessageException(string message) :base(message)
        {
            
        }
    }
}
