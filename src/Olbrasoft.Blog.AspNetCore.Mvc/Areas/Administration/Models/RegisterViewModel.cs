using System.ComponentModel.DataAnnotations;
using Olbrasoft.Blog.AspNetCore.Mvc.Resources;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models
{
    public class RegisterViewModel
    {
        [StringLength(100, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Shared))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Shared))]
        [Display(Name = "FirstName", Prompt = "FirstName", ResourceType = typeof(Shared))]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Shared))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Shared))]
        [Display(Name = "LastName", Prompt = "LastName", ResourceType = typeof(Shared))]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessageResourceName = "TheEmailFieldIsRequired", ErrorMessageResourceType = typeof(Shared))]
        [Display(Name = "EmailAddress", Prompt = "EmailAddress", ResourceType = typeof(Shared))]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessageResourceName = "ThePasswordFieldIsRequired", ErrorMessageResourceType = typeof(Shared))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "RepeatPassword", Prompt = "RepeatPassword", ResourceType = typeof(Shared))]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}