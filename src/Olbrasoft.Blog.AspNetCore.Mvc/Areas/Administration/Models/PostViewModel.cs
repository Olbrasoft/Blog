﻿namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;

public class PostViewModel
{
    public int Id { get; set; }

    private const int _length = 33;

    [StringLength(_length, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Display(Name = "Title", Prompt = "PostTitle", ResourceType = typeof(Resources.SharedResources))]
    public string Title { get; set; }

    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Display(Name = "Content", Prompt = "PostContent", ResourceType = typeof(Resources.SharedResources))]
    public string Content { get; set; }

    public int MaxLength { get; set; } = _length;

    public IEnumerable<CategorySmallDto> Categories { get; set; } = new HashSet<CategoryOfUserDto>();

    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    public int CategoryId { get; set; }

    public string TagIds { get; set; } = "";

    public IEnumerable<TagSmallDto> Tags { get; set; } = new HashSet<TagSmallDto>();
}