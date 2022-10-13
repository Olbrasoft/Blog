using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Olbrasoft.Blog.AspNetCore.Mvc.Models;
using Olbrasoft.Blog.Business;
using Olbrasoft.Blog.Data.Queries;
using Olbrasoft.Data.Cqrs;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Paging.X.PagedList.AspNetCore.Mvc;
using Olbrasoft.Dispatching;
using Olbrasoft.Extensions.Paging;
using Olbrasoft.Linq;
using System.Diagnostics;
using System.Threading;
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
        private readonly IDispatcher _dispatcher;
        private readonly IQueryProcessor _processor;

        public HomeController(ILogger<HomeController> logger,
            IPostService postService,
            ICategoryService categoryService,
            ITagService tagService,
            ICommentService commentService,
            IStringLocalizer<HomeController> localizer,
            IDispatcher dispatcher,
            IQueryProcessor processor)

        {
            _logger = logger;
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
            _commentService = commentService;
            _localizer = localizer;
            _dispatcher = dispatcher;
            _processor = processor;
        }

        public async Task<IActionResult> IndexAsync(string query, string search, CancellationToken token, int page = 1)
        {
            //var cultureInfo = new CultureInfo("cs");
            //CultureInfo.DefaultThreadCurrentCulture = cultureInfo;

            var paging = new PageInfo(3, page);

            if (string.IsNullOrEmpty(search)) search = query;

            var model = new HomePageViewModel
            {
                Posts = (await _postService.PostsAsync(search, paging, token)).AsPagedList(paging),
                NestedModel = await BuildNestedModel(token)
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

        public async Task<IActionResult> TestSpeedDiContainer()
        {
            var model = new SpeedModel();
            var query = new SpeedQuery(_processor);

            var timer = new Stopwatch();

            timer.Start();
            for (int i = 0; i < 100000000; i++)
            {
                model.Hello = await query.ToResultAsync();
            }

            timer.Stop();
            model.TimeTaken = timer.Elapsed;

            return View(model);
        }

        public async Task<IActionResult> PostAsync(int id, CancellationToken token, int commentId = 0, int parentCommentId = 0)
        {
            if (id < 1) return RedirectToAction("Index");

            var model = new PostDetailViewModel
            {
                Id = id,
                Post = (await _postService.PostAsync(id, token)),
                NestedModel = await BuildNestedModel(token),
                Comments = await _commentService.CommentsByPostIdAsync(id, token),
                CommentId = commentId,
                ParentCommentId = parentCommentId
            };

            if (parentCommentId > 0)
            {
                model.CommentText = await _commentService.TextEditNestedComment(commentId, CurrentUserId, token);
                model.CommentedCommentText = await _commentService.TextEditComment(parentCommentId, 0, token);
            }
            else
            {
                if (commentId > 0) model.CommentText = await _commentService.TextEditComment(commentId, CurrentUserId, token);
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

        private async Task<RightColumnViewModel> BuildNestedModel(CancellationToken token)
        {
            return new RightColumnViewModel
            {
                Categories = (await _categoryService.CategoriesAsync(token)).SplitToTwo(),
                Tags = (await _tagService.TagsAsync(token)).SplitToTwo()
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}