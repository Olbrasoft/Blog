using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Controllers
{
    public abstract class BlogController : Controller
    {
        public int CurrentUserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}