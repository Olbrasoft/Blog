using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;
using Olbrasoft.Blog.Business;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Paging.DataTables;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class CategoriesController : AdminDataTablesController
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service, IDataTableBuilder builder) : base(builder)
        {
            _service = service;
        }

        public async Task<IActionResult> IndexAsync(int id = 0)
        {
            var model = new CategoriesViewModel();

            if (id > 0) //edit category
            {
                var category = await _service.CategoryAsync(id);
                model.Id = category.Id;
                model.Name = category.Name;
                model.Tooltip = category.Tooltip;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(CategoriesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _service.SaveAsync(model.Id, model.Name, model.Tooltip, int.Parse(userId));

                return RedirectToAction("Index");
            }

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> CurrentUserCategoriesAsync([FromBody] DataTableModel dtParameters)
        {
            var option = BuildDataTableQueryOption(dtParameters, nameof(CategoryOfUserDto.Name));

            var categories = await _service.CategoriesByUserIdAsync(CurrentUserId, option.Paging, option.Column, option.Direction, option.Search);

            return BuildDataTableJson(categories);
        }

        [HttpPost]
        public async Task<IActionResult> OtherUsersCategoriesAsync([FromBody] DataTableModel dtParameters)
        {
            var option = BuildDataTableQueryOption(dtParameters, nameof(CategoryOfUsersDto.Name));

            var categories = await _service.CategoriesByExceptUserIdAsync(CurrentUserId, option.Paging, option.Column, option.Direction, option.Search);

            return BuildDataTableJson(categories);
        }

        public async Task<IActionResult> NotExistsAsync(int Id, string name)
        {
            var exists = await _service.ExistsAsync(Id, name);
            return Json(!exists);
        }
    }
}