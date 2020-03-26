using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Olbrasoft.Blog.AspNetCore.Mvc.Models;
using Olbrasoft.Blog.Business;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Paging.X.PagedList;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        public HomeController(ILogger<HomeController> logger, IPostService postService, ICategoryService categoryService, ITagService tagService)
        {
            _logger = logger;
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        public async Task<IActionResult> IndexAsync(int pageNumber = 1)
        {
            var paging = new PageInfo(3, pageNumber);

            var model = new HomePageViewModel
            {
                Posts = (await _postService.PostsAsync(paging)).AsPagedList(paging),
                NestedModel = await BuildNestedModel()
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
                NestedModel = await BuildNestedModel()
            };

            return View(model);
        }

        private async Task<RightColumnViewModel> BuildNestedModel()
        {
            return new RightColumnViewModel
            {
                Categories = (await _categoryService.CategoriesAsync()).SplitToTwo(),
                Tags = (await _tagService.TagsAsync()).SplitToTwo()
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}