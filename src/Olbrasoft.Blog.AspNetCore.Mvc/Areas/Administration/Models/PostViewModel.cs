﻿namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;

public class PostViewModel
{
    public int Id { get; set; }

    private const int _length = 33 ;
    private string _title = string.Empty;
   

    [StringLength(_length, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Display(Name = "Title", Prompt = "PostTitle", ResourceType = typeof(Resources.SharedResources))]
    public string Title
    {
        get => _title; set
        {
            _title = value;
           
        }
    }


    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Display(Name = "Content", Prompt = "PostContent", ResourceType = typeof(Resources.SharedResources))]
    public string Content { get; set; } = string.Empty;

    public int MaxLength { get; set; } = _length;

    public IEnumerable<CategorySmallDto> Categories { get; set; } = new HashSet<CategoryOfUserDto>();

    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    public int CategoryId { get; set; }

    public string? TagIds { get; set; } = string.Empty;

    public IEnumerable<TagSmallDto> Tags { get; set; } = new HashSet<TagSmallDto>();
}