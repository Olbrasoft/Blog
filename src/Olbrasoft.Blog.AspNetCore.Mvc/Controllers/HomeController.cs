using Microsoft.AspNetCore.Mvc;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Post()
        {
            return View();
        }
    }
}