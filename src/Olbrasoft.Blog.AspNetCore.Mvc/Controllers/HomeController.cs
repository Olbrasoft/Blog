using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Olbrasoft.Blog.AspNetCore.Mvc.Models;
using Olbrasoft.Blog.Business;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Paging.X.PagedList;
using Olbrasoft.Data.Paging.X.PagedList.AspNetCore.Mvc;
using Olbrasoft.Linq;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Controllers
{
    public class HomeController : BlogController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly ICommentService _commentService;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, IPostService postService, ICategoryService categoryService, ITagService tagService, ICommentService commentService, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
            _commentService = commentService;
            _localizer = localizer;
        }

        public async Task<IActionResult> IndexAsync(string query, string search, int page = 1)
        {
            //var cultureInfo = new CultureInfo("cs");
            //CultureInfo.DefaultThreadCurrentCulture = cultureInfo;

            var paging = new PageInfo(3, page);

            if (string.IsNullOrEmpty(search)) search = query;

            var model = new HomePageViewModel
            {
                Posts = (await _postService.PostsAsync(search, paging)).AsPagedList(paging),
                NestedModel = await BuildNestedModel()
            };

            var options = PagedListRenderOptions.Bootstrap4PageNumbersPlusPrevAndNext;
            options.UlElementClasses = new[] { "justify-content-center", "pagination" };
            options.LinkToPreviousPageFormat = "&larr; " + _localizer["Newer"].ToString();
            options.LinkToNextPageFormat = _localizer["Older"].ToString() + " &rarr;";

            model.Options = options;

            model.NestedModel.CurrentQuery = search;

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> PostAsync(int id, int commentId = 0, int parentCommentId = 0)
        {
            if (id < 1) return RedirectToAction("Index");

            var model = new PostDetailViewModel
            {
                Id = id,
                Post = (await _postService.PostAsync(id)),
                NestedModel = await BuildNestedModel(),
                Comments = await _commentService.CommentsByPostIdAsync(id)
            };

            model.CommentId = commentId;
            model.ParentCommentId = parentCommentId;

            if (parentCommentId > 0)
            {
                model.CommentText = await _commentService.TextEditNestedComment(commentId, CurrentUserId);
                model.CommentedCommentText = await _commentService.TextEditComment(parentCommentId);
            }
            else
            {
                if (commentId > 0)
                    model.CommentText = await _commentService.TextEditComment(commentId, CurrentUserId);
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveCommentAsync(PostDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ParentCommentId > 0)
                    await _commentService.SaveNestedCommentAsync(model.CommentId, model.ParentCommentId, model.CommentText, CurrentUserId);
                else
                    await _commentService.SaveAsync(model.CommentId, model.Id, model.CommentText, CurrentUserId);
            }

            return RedirectToAction("Post", new { id = model.Id });
        }

        [Authorize]
        public async Task<IActionResult> DeleteNestedCommentAsync(int postId, int nestedCommentId)
        {
            await _commentService.DeleteNestedComment(nestedCommentId, CurrentUserId);

            return RedirectToAction("Post", new { id = postId });
        }

        [Authorize]
        public async Task<IActionResult> DeleteCommentAsync(int postId, int commentId)
        {
            await _commentService.DeleteComment(commentId, CurrentUserId);

            return RedirectToAction("Post", new { id = postId });
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