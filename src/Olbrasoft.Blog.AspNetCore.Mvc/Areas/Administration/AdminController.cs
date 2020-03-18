using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration
{

    [Authorize]
    [Area("Administration")]
    public abstract class AdminController : Controller
    {
        public int CurrentUserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));


    }
}