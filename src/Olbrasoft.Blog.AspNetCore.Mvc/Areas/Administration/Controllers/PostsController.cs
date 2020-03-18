using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;
using Olbrasoft.Blog.Business;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class PostsController : AdminController
    {
        private readonly ICategoryService _categoryService;

        private readonly ITagService _tagService;

        private readonly IPostService _service;

        public PostsController(ICategoryService categoryService, ITagService tagService, IPostService service)
        {
            _categoryService = categoryService;
            _tagService = tagService;
            _service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = new PostViewModel
            {
                Categories = await _categoryService.CategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.SaveAsync(model.Title, model.Content, model.CategoryId, CurrentUserId, model.TagIds.Split(',').Select(p => int.Parse(p)), model.Id);

                return RedirectToAction("Index");
            }

            if (!string.IsNullOrEmpty(model.TagIds))
            {
                model.Tags = await _tagService.TagsByIds(model.TagIds.Split(',').Select(p => int.Parse(p)));
            }

            model.Categories = await _categoryService.CategoriesAsync();
            return View("Index", model);
        }

        [HttpGet]
        public async Task<IActionResult> FindTags(string term, string values)
        {
            IEnumerable<int> exceptTagIds = new HashSet<int>();

            if (!string.IsNullOrEmpty(values))
            {
                exceptTagIds = values.Split(',').Select(p => int.Parse(p));
            }

            var tags = await _tagService.Find(term, exceptTagIds);

            return Json(tags.Select(p => new TagModel { Value = p.Id, Text = p.Label }));
        }
    }
}