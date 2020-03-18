using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}