using System.ComponentModel.DataAnnotations;
using Olbrasoft.Blog.AspNetCore.Mvc.Properties;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models
{
    public class RegisterViewModel
    {
        [StringLength(100, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "FirstName", Prompt = "FirstName", ResourceType = typeof(Resources))]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "LastName", ResourceType = typeof(Resources))]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]

        public string ConfirmPassword { get; set; } = string.Empty;

    }
}