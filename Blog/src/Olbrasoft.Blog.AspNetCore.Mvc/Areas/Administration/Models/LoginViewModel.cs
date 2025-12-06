namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;

public class LoginViewModel
{
    [Required(ErrorMessageResourceName = "TheEmailFieldIsRequired", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [Display(Name = "EmailAddress", Prompt = "EmailAddress", ResourceType = typeof(Resources.SharedResources))]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessageResourceName = "ThePasswordFieldIsRequired", ErrorMessageResourceType = typeof(Resources.SharedResources))]
    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Password", ResourceType = typeof(Resources.SharedResources))]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}