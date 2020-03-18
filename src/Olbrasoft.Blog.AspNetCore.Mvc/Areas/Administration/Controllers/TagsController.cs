using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration;
using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;
using Olbrasoft.Blog.Business;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Paging.DataTables;
using Olbrasoft.Paging;
using System.Linq;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class TagsController : AdminController
    {
        private readonly ITagService _service;

        public TagsController(ITagService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int id = 0)
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
        public async Task<IActionResult> Save(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.SaveAsync(model.Id, model.Label, CurrentUserId);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", model);
        }

        private DataTableQueryOption BuildOption(DataTableModel dtParameters)
        {
            var result = new DataTableQueryOption
            {
                Search = dtParameters.Search.Value,
                Direction = OrderDirection.Asc,
                Column = nameof(TagDto.Label)
            };

            var page = 1;

            if (dtParameters.Start != 0)
            {
                page = dtParameters.Start / dtParameters.Length + 1;
            }

            result.Paging = new PageInfo(dtParameters.Length, page);

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                result.Column = dtParameters.Columns[dtParameters.Order[0].Column].Name;

                if (dtParameters.Order[0].Dir.ToString().ToLower() == nameof(OrderDirection.Desc).ToLower())
                {
                    result.Direction = OrderDirection.Desc;
                }
            }

            return result;
        }

        private JsonResult BuildJson(IPagedResult<TagDto> tags)
        {
            return Json(new
            {
                recordsTotal = tags.TotalCount,
                recordsFiltered = tags.FilteredCount,
                data = tags.Records
            });
        }

        [HttpPost]
        public async Task<IActionResult> CurrentUserTags([FromBody] DataTableModel dtParameters)
        {
            var option = BuildOption(dtParameters);

            var tags = await _service.UserTagsAsync(CurrentUserId, option.Paging, option.Column, option.Direction, option.Search);

            return BuildJson(tags);
        }

        [HttpPost]
        public async Task<IActionResult> OtherUsersTags([FromBody] DataTableModel dtParameters)
        {
            var option = BuildOption(dtParameters);

            var tags = await _service.OtherUsersTags(CurrentUserId, option.Paging, option.Column, option.Direction, option.Search);

            return BuildJson(tags);
        }

        public async Task<JsonResult> NotExists(int Id, string label)
        {
            var exists = await _service.ExistsAsync(Id, label);
            return Json(!exists);
        }





    }
}