using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Olbrasoft.Blog.AspNetCore.Mvc.Models;
using Olbrasoft.Blog.Business;
using Olbrasoft.Paging;
using Olbrasoft.Paging.X.PagedList;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger, IPostService postService, ICategoryService categoryService)
        {
            _logger = logger;
            _postService = postService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var paging = new PageInfo(3, 1);

            var model = new HomePageViewModel
            {
                Posts = (await _postService.PostsAsync(paging)).AsPagedList(paging),
                Categories = (await _categoryService.CategoriesAsync()).SplitToTwo()
            };

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> PostAsync(int id)
        {
            if (id < 1) return RedirectToAction("Index");
            
            var model = new PostDetailViewModel
            {
                Post = (await _postService.PostAsync(id)),
                Categories = (await _categoryService.CategoriesAsync()).SplitToTwo()
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}