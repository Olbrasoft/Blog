using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;
using Olbrasoft.Blog.Business;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Paging.DataTables;
using System.Linq;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class PostsController : AdminDataTablesController
    {
        private readonly ICategoryService _categoryService;

        private readonly ITagService _tagService;

        private readonly IPostService _service;

        public PostsController(ICategoryService categoryService, ITagService tagService, IPostService service, IDataTableBuilder builder) : base(builder)
        {
            _categoryService = categoryService;
            _tagService = tagService;
            _service = service;
        }

        public async Task<IActionResult> IndexAsync(int id = 0)
        {

            var model = new PostViewModel
            {
                Categories = await _categoryService.CategoriesAsync()
            };

            if (id > 0) //edit post
            {
                var post = await _service.PostForEditingByIdAsync(id);

                model.Id = post.Id;

                model.Title = post.Title;

                model.Content = post.Content;

                model.CategoryId = post.CategoryId;

                if(post.TagIds.Any())
                {
                    model.Tags = await _tagService.TagsByIds(post.TagIds);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(PostViewModel model)
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

            model.Categories = await _categoryService.CategoriesAsync();
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> CurrentUserPostsAsync([FromBody] DataTableModel dtParameters)
        {
            var option = BuildDataTableQueryOption(dtParameters, nameof(PostOfUserDto.Title));

            var posts = await _service.PostsByUserIdAsync(CurrentUserId, option.Paging, option.Column, option.Direction, option.Search);

            return BuildDataTableJson(posts);
        }
    }
}