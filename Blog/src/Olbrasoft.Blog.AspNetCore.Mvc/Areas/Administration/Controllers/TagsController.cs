namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers;

public class TagsController : AdminDataTablesController
{
    private readonly ITagService _service;

    public TagsController(ITagService service, IDataTableOptionBuilder builder) : base(builder)
    {
        _service = service;
    }

    public async Task<IActionResult> IndexAsync(int id, CancellationToken token)
    {
        var model = new TagViewModel();

        if (id > 0)
        {
            var tag = await _service.UserTagAsync(id, CurrentUserId, token);

            model.Id = tag.Id;
            model.Label = tag.Label;
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> SaveAsync(TagViewModel model, CancellationToken token)
    {
        if (ModelState.IsValid)
        {
            await _service.SaveAsync(model.Id, model.Label, CurrentUserId, token);

            return RedirectToAction("Index");
        }

        return View("Index", model);
    }

    [HttpPost]
    public async Task<IActionResult> CurrentUserTagsAsync([FromBody] DataTableModel model, CancellationToken token)
    {
        //CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture.Name;
        //CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

        var option = BuildDataTableQueryOption(model, nameof(TagOfUserDto.Label));

        var tags = await _service.TagsByUserIdAsync(CurrentUserId, option.Paging, option.Column, option.Direction, option.Search, token);

        return BuildDataTableJson(tags);
    }

    [HttpPost]
    public async Task<IActionResult> OtherUsersTagsAsync([FromBody] DataTableModel dtParameters, CancellationToken token)
    {
        var option = BuildDataTableQueryOption(dtParameters, nameof(TagOfUsersDto.Label));

        var tags = await _service.TagsByExceptUserIdAsync(CurrentUserId, option.Paging, option.Column, option.Direction, option.Search, token);

        return BuildDataTableJson(tags);
    }

    [HttpGet]
    public async Task<IActionResult> FindTagsAsync(string term, string values, CancellationToken token)
    {
        IEnumerable<int> exceptTagIds = new HashSet<int>();

        if (!string.IsNullOrEmpty(values))
        {
            exceptTagIds = values.Split(',').Select(p => int.Parse(p));
        }

        var tags = await _service.FindAsync(term, exceptTagIds, token);

        return Json(tags.Select(p => new TagModel { Value = p.Id, Text = p.Label }));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int tagId, CancellationToken token)
    {
        await _service.DeleteAsync(tagId, CurrentUserId, token);  

        return Json("Deleted");
    }

    public async Task<JsonResult> NotExistsAsync(int Id, string label, CancellationToken token)
    {
        var exists = await _service.ExistsAsync(Id, label, token);
        return Json(!exists);
    }
}