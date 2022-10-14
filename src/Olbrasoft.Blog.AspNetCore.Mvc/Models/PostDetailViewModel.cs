using Olbrasoft.Blog.Data.Dtos.CommentDtos;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Models;

public class PostDetailViewModel : HomeAndPostModel
{
    public PostDto Post { get; set; }

    public int Id { get; set; }

    public int ParentCommentId { get; set; }

    public int CommentId { get; set; }

    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Display(Name = "Text", Prompt = "CommentText", ResourceType = typeof(Resources.SharedResources))]
    public string CommentText { get; set; }

    public string CommentedCommentText { get; set; }

    public IEnumerable<CommentDto> Comments { get; set; }
}