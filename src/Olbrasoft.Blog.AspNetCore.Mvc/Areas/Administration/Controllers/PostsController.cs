﻿namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers;

public class PostsController(ICategoryService categoryService, ITagService tagService, IPostService service, IDataTableOptionBuilder builder) : AdminDataTablesController(builder)
{
    private readonly ICategoryService _categoryService = categoryService;

    private readonly ITagService _tagService = tagService;

    private readonly IPostService _service = service;

    public async Task<IActionResult> IndexAsync(int id = 0, CancellationToken token = default)
    {
        var model = new PostViewModel
        {
            Categories = await _categoryService.CategoriesAsync(token)
        };

        if (id > 0) //edit post
        {
            var post = await _service.PostForEditingByIdAsync(id, token);

            model.Id = post.Id;

            model.Title = post.Title;

            model.Content = post.Content;

            model.CategoryId = post.CategoryId;

            model.Tags = post.Tags;

            model.DefaultImageNameAndExtension = post.DefaultImageNameAndExtension;
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> SaveAsync(PostViewModel model, CancellationToken token)
    {
        if (ModelState.IsValid)
        {
            if (!string.IsNullOrEmpty(model.TagIds))
            {
                await _service.SaveAsync(model.Image, model.Title, model.Content, model.CategoryId, CurrentUserId, model.TagIds.Split(',').Select(int.Parse), model.Id, model.DeleteDefaultImage, token);
            }
            else
            {
                await _service.SaveAsync(model.Image, model.Title, model.Content, model.CategoryId, CurrentUserId, [], model.Id, model.DeleteDefaultImage, token);
            }

            return RedirectToAction("Index");
        }

        //If error javascript validation
        if (!string.IsNullOrEmpty(model.TagIds))
        {
            model.Tags = await _tagService.TagsByIds(model.TagIds.Split(',').Select(p => int.Parse(p)), token);
        }

        model.Categories = await _categoryService.CategoriesAsync(token);
        return View("Index", model);
    }

    [HttpPost]
    public async Task<IActionResult> CurrentUserPostsAsync([FromBody] BlogDataTableModel model, CancellationToken token)
    {

        var option = BuildDataTableQueryOption(model, nameof(PostOfUserDto.Title));

        IPagedResult<PostOfUserDto> posts = await _service.PostsByUserIdAsync(CurrentUserId, model.EditingId, option.Paging, option.Column, option.Direction, option.Search, token);

        return BuildDataTableJson(posts);
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int postId, CancellationToken token)
    {
        await _service.DeletePostAsync(postId, CurrentUserId, token);

        return Json("Deleted");
    }
}


public class BlogDataTableModel : DataTableModel
{
    public int EditingId { get; set; }
}
