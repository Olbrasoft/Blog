namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;

public class PostViewModel
{
    public int Id { get; set; }

    private const int _length = 33;

    [StringLength(_length, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Display(Name = "Title", Prompt = "PostTitle", ResourceType = typeof(Resources.SharedResources))]
    public string Title { get; set; } = string.Empty;


    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Display(Name = "Content", Prompt = "PostContent", ResourceType = typeof(Resources.SharedResources))]
    public string Content { get; set; } = string.Empty;

    public int MaxLength { get; set; } = _length;

    public IEnumerable<CategorySmallDto> Categories { get; set; } = [];

    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    public int CategoryId { get; set; }

    public string? TagIds { get; set; } = string.Empty;

    public IEnumerable<TagSmallDto> Tags { get; set; } = [];

    public IFormFile? Image { get; set; } = null!;

    public bool DeleteDefaultImage { get; set; }

    public string DefaultImageNameAndExtension { get; set; } = string.Empty;
}