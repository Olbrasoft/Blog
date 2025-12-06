using Olbrasoft.Blog.Data.Dtos.CommentDtos;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Models;

public class PostDetailViewModel : HomeAndPostModel
{
    public int CurentUserId { get; set; }

    public PostDto Post { get; set; } = new PostDto();

    public int Id { get; set; }

    public int ParentCommentId { get; set; }

    public int CommentId { get; set; }

    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Display(Name = "Text", Prompt = "CommentText", ResourceType = typeof(Resources.SharedResources))]
    public string CommentText { get; set; } = string.Empty;

    public string CommentedCommentText { get; set; } = string.Empty;

    public IEnumerable<CommentDto> Comments { get; set; } = Enumerable.Empty<CommentDto>();

}