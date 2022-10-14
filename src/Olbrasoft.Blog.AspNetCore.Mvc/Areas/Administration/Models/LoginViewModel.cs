namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;

public class LoginViewModel
{
    [Required(ErrorMessageResourceName = "TheEmailFieldIsRequired", ErrorMessageResourceType = typeof(SharedResources))]
    [Display(Name = "EmailAddress", Prompt = "EmailAddress", ResourceType = typeof(SharedResources))]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessageResourceName = "ThePasswordFieldIsRequired", ErrorMessageResourceType = typeof(SharedResources))]
    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Password", ResourceType = typeof(SharedResources))]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}