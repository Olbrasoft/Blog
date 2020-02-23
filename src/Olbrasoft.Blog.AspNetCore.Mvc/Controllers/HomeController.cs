using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Blog.AspNetCore.Mvc.Models;

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


        public IActionResult Edit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Edit( PostModel post )
        {
         return  RedirectToAction("Index");
        }
    }
}