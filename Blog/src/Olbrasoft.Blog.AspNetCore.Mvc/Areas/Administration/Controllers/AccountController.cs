using Microsoft.AspNetCore.Identity;
using Olbrasoft.Mapping;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers;

[Area("Administration")]
public class AccountController : Controller
{
    private readonly IMapper _mapper;
    private readonly UserManager<BlogUser> _userManager;
    private readonly SignInManager<BlogUser> _signInManager;

    public AccountController(IMapper mapper, UserManager<BlogUser> userManager, SignInManager<BlogUser> signInManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home", new { area = string.Empty });
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = _mapper.MapTo<BlogUser>(model);

        var userExists = await _userManager.Users.AnyAsync();

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            if (userExists)
            {
                await _userManager.AddToRoleAsync(user, "Blogger");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Administrator");
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("index", "home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginAsync(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home", new { area = "Administration" });
            }
        }
        return View(model);
    }
}