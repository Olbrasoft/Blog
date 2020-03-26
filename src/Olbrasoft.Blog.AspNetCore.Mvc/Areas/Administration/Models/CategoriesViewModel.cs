using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Blog.AspNetCore.Mvc.Properties;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models
{
    public class CategoriesViewModel
    {
        public int Id { get; set; }

        [Remote("NotExists", "Categories", "Administration", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "CategoryExist", ErrorMessageResourceType = typeof(Resources))]
        [StringLength(25, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "Name", Prompt = "CategoryName", ResourceType = typeof(Resources))]
        public string Name { get; set; } = string.Empty;

        [StringLength(50, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "Tooltip", Prompt = "CategoryTooltip", ResourceType = typeof(Resources))]
        public string Tooltip { get; set; } = string.Empty;

        public int TooltipLength { get; set; } = 100;

        public int NameMaxLength { get; set; } = 50;

        public bool DoNotExists { get; set; }

        public IPagedList<CategoryOfUserDto> Categories { get; set; }

        public string SortName { get; set; } = string.Empty;

    }
}