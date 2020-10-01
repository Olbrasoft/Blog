using Olbrasoft.Blog.AspNetCore.Mvc.Resources;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceName = "TheEmailFieldIsRequired", ErrorMessageResourceType = typeof(Shared))]
        [Display(Name = "EmailAddress", Prompt = "EmailAddress", ResourceType = typeof(Shared))]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessageResourceName = "ThePasswordFieldIsRequired", ErrorMessageResourceType = typeof(Shared))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password", ResourceType = typeof(Shared))]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}