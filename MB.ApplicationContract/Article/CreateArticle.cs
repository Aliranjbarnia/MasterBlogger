using System.ComponentModel.DataAnnotations;

namespace MB.ApplicationContract.Article;

public class CreateArticle
{
    [Required(ErrorMessage = "Please Enter Title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please Enter ShortDescription")]
    public string ShortDescription { get; set; }

    [Required(ErrorMessage = "Please Enter Image Link")]
    public string Image { get; set; }

    [Required(ErrorMessage = "Please Enter Long Description")]
    public string Content { get; set; }

    [Required(ErrorMessage = "Please Choice Category Item")]
    public int ArticleCategoryId { get; set; }

}