using Microsoft.Extensions.Localization;
using Olbrasoft.Blog.AspNetCore.Mvc.Models;
using Olbrasoft.Data.Paging.X.PagedList.AspNetCore.Mvc;
using Olbrasoft.Extensions.Paging;
using Olbrasoft.Linq;
using System.Diagnostics;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Controllers;

public class HomeController : BlogController
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPostService _postService;
    private readonly ICategoryService _categoryService;
    private readonly ITagService _tagService;
    private readonly ICommentService _commentService;
    private readonly IStringLocalizer<HomeController> _localizer;


    public HomeController(ILogger<HomeController> logger,
        IPostService postService,
        ICategoryService categoryService,
        ITagService tagService,
        ICommentService commentService,
        IStringLocalizer<HomeController> localizer

        )

    {
        _logger = logger;
        _postService = postService;
        _categoryService = categoryService;
        _tagService = tagService;
        _commentService = commentService;
        _localizer = localizer;

    }

    public async Task<IActionResult> IndexAsync(string query, string search, CancellationToken token, int page = 1)
    {
        var paging = new PageInfo(3, page);

        if (string.IsNullOrEmpty(search)) search = query;

        var model = new HomePageViewModel
        {
            Posts = (await _postService.PostsAsync(search, paging, token)).AsPagedList(paging),
            NestedModel = await BuildNestedModel(token)
        };

        _logger.LogInformation($"Total posts:{model.Posts.TotalItemCount}");

        var options = PagedListRenderOptions.Bootstrap4PageNumbersPlusPrevAndNext;
        options.UlElementClasses = ["justify-content-center", "pagination"];
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

    public async Task<IActionResult> PostAsync(int id, CancellationToken token, int commentId = 0, int parentCommentId = 0)
    {

        if (id < 1) return RedirectToAction("Index");

        var model = new PostDetailViewModel
        {
            Id = id,
            CurentUserId = CurrentUserId,
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

    public async Task<IActionResult> DefaultImageAsync(int blogId, string extension, CancellationToken token)
    {
        var image = await _postService.GetDefaultImageAsync(blogId, extension, token);

        return image.ImageContent is null ? NotFound() : File(image.ImageContent, image.ImageContentType);
    }

 
    public async Task<IActionResult> GetDefaultImagesAsync(int postId, string imagefileNameAndExtension, CancellationToken token)
    {
        if(! await _postService.CheckDefaultImage(postId, imagefileNameAndExtension) ) return NotFound() ;
           
        var extension = Path.GetExtension(imagefileNameAndExtension);

        if (postId == 0 || string.IsNullOrEmpty(extension)) return NotFound();

        var img = await _postService.GetDefaultImageAsync(postId, extension, token);

        return img.ImageContent is null ? NotFound() : File(img.ImageContent, img.ImageContentType);

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