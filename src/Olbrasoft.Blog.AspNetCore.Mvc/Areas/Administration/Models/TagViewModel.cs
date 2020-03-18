using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Blog.AspNetCore.Mvc.Properties;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }

        [Remote("NotExists", "Tags", "Administration", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "TagExist", ErrorMessageResourceType = typeof(Resources))]
        [StringLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "Label", Prompt = "TagLabel", ResourceType = typeof(Resources))]
        public string Label { get; set; } = string.Empty;

        public int MaxLength { get; set; } = 25;

        public bool DoNotExists { get; set; }
    }
}