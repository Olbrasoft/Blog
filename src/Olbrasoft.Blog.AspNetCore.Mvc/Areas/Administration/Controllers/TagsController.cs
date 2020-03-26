using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;
using Olbrasoft.Blog.Business;
using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Data.Paging.DataTables;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class TagsController : AdminDataTablesController
    {
        private readonly ITagService _service;

        public TagsController(ITagService service, IDataTableBuilder builder) : base(builder)
        {
            _service = service;
        }

        public async Task<IActionResult> IndexAsync(int id = 0)
        {
            var model = new TagViewModel();

            if (id > 0)
            {
                var tag = await _service.UserTagAsync(id, CurrentUserId);

                model.Id = tag.Id;
                model.Label = tag.Label;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.SaveAsync(model.Id, model.Label, CurrentUserId);

                return RedirectToAction("Index");
            }

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> CurrentUserTagsAsync([FromBody] DataTableModel model)
        {
            var option = BuildDataTableQueryOption(model, nameof(TagOfUserDto.Label));

            var tags = await _service.TagsByUserIdAsync(CurrentUserId, option.Paging, option.Column, option.Direction, option.Search);

            return BuildDataTableJson(tags);
        }

        [HttpPost]
        public async Task<IActionResult> OtherUsersTagsAsync([FromBody] DataTableModel dtParameters)
        {
            var option = BuildDataTableQueryOption(dtParameters, nameof(TagOfUsersDto.Label));

            var tags = await _service.TagsByExceptUserIdAsync(CurrentUserId, option.Paging, option.Column, option.Direction, option.Search);

            return BuildDataTableJson(tags);
        }

        [HttpGet]
        public async Task<IActionResult> FindTagsAsync(string term, string values)
        {
            IEnumerable<int> exceptTagIds = new HashSet<int>();

            if (!string.IsNullOrEmpty(values))
            {
                exceptTagIds = values.Split(',').Select(p => int.Parse(p));
            }

            var tags = await _service.FindAsync(term, exceptTagIds);

            return Json(tags.Select(p => new TagModel { Value = p.Id, Text = p.Label }));
        }

        public async Task<JsonResult> NotExistsAsync(int Id, string label)
        {
            var exists = await _service.ExistsAsync(Id, label);
            return Json(!exists);
        }
    }
}