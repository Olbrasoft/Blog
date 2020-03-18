using Olbrasoft.Blog.AspNetCore.Mvc.Properties;
using Olbrasoft.Blog.Data.Dtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        private const int _length = 33;

        [StringLength(_length, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "Title", Prompt = "PostTitle", ResourceType = typeof(Resources))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "Content", Prompt = "PostContent", ResourceType = typeof(Resources))]
        public string Content { get; set; }

        public int MaxLength { get; set; } = _length;

        public IEnumerable<CategorySmallDto> Categories { get; set; } = new HashSet<CategoryOfUserDto>();

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources))]
        public int CategoryId { get; set; }

        public string TagIds { get; set; }

        public IEnumerable<TagBasicDto> Tags { get; set; } = new HashSet<TagBasicDto>();
    }
}