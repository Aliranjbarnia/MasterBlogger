using System.ComponentModel.DataAnnotations;

namespace MB.ApplicationContract.ArticleCategory
{
    public class CreateCategory
    {
        [Required(ErrorMessage = "لطفاً عنوان را وارد نمائید")]
        public string Title { get; set; }
    }
}
