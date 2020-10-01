using Olbrasoft.Blog.AspNetCore.Mvc.Resources;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.Dtos.TagDtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        private const int _length = 33;

        [StringLength(_length, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Shared))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Shared))]
        [Display(Name = "Title", Prompt = "PostTitle", ResourceType = typeof(Shared))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Shared))]
        [Display(Name = "Content", Prompt = "PostContent", ResourceType = typeof(Shared))]
        public string Content { get; set; }

        public int MaxLength { get; set; } = _length;

        public IEnumerable<CategorySmallDto> Categories { get; set; } = new HashSet<CategoryOfUserDto>();

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Shared))]
        public int CategoryId { get; set; }

        public string TagIds { get; set; } = "";

        public IEnumerable<TagSmallDto> Tags { get; set; } = new HashSet<TagSmallDto>();
    }
}