using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;
using Olbrasoft.Blog.Business;
using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Data.Paging.DataTables;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class PostsController : AdminDataTablesController
    {
        private readonly ICategoryService _categoryService;

        private readonly ITagService _tagService;

        private readonly IPostService _service;

        public PostsController(ICategoryService categoryService, ITagService tagService, IPostService service, IDataTableOptionBuilder builder) : base(builder)
        {
            _categoryService = categoryService;
            _tagService = tagService;
            _service = service;
        }

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

                model.Tags = await _tagService.TagsByPostIdAsync(id, token);
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
                    await _service.SaveAsync(model.Title, model.Content, model.CategoryId, CurrentUserId, model.TagIds.Split(',').Select(p => int.Parse(p)), model.Id);
                }
                else
                {
                    await _service.SaveAsync(model.Title, model.Content, model.CategoryId, CurrentUserId, null, model.Id);
                }

                return RedirectToAction("Index");
            }

            //If error javascript validation
            if (!string.IsNullOrEmpty(model.TagIds))
            {
                model.Tags = await _tagService.TagsByIds(model.TagIds.Split(',').Select(p => int.Parse(p)));
            }

            model.Categories = await _categoryService.CategoriesAsync(token);
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> CurrentUserPostsAsync([FromBody] DataTableModel model, CancellationToken token)
        {
            var option = BuildDataTableQueryOption(model, nameof(PostOfUserDto.Title));

            var posts = await _service.PostsByUserIdAsync(CurrentUserId, option.Paging, option.Column, option.Direction, option.Search, token);

            return BuildDataTableJson(posts);
        }
    }
}