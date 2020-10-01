using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Blog.AspNetCore.Mvc.Controllers;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    [Authorize]
    [Area("Administration")]
    public class HomeController : BlogController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}