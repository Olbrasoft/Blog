namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;

public class RegisterViewModel
{
    [StringLength(100, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(SharedResources))]
    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(SharedResources))]
    [Display(Name = "FirstName", Prompt = "FirstName", ResourceType = typeof(SharedResources))]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(100, ErrorMessageResourceName = "Validation_MaxLength", ErrorMessageResourceType = typeof(SharedResources))]
    [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(SharedResources))]
    [Display(Name = "LastName", Prompt = "LastName", ResourceType = typeof(SharedResources))]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessageResourceName = "TheEmailFieldIsRequired", ErrorMessageResourceType = typeof(SharedResources))]
    [Display(Name = "EmailAddress", Prompt = "EmailAddress", ResourceType = typeof(SharedResources))]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessageResourceName = "ThePasswordFieldIsRequired", ErrorMessageResourceType = typeof(SharedResources))]
    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Password")]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "RepeatPassword", Prompt = "RepeatPassword", ResourceType = typeof(SharedResources))]
    [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}