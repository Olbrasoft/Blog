namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers;

[Authorize]
[Area("Administration")]
public class AdminDataTablesController : BlogController
{
    private readonly IDataTableOptionBuilder _builder;

    public AdminDataTablesController(IDataTableOptionBuilder builder)
    {
        _builder = builder;
    }

    protected IActionResult BuildDataTableJson<T>(IPagedResult<T> result)
    {
        return Json(new
        {
            recordsTotal = result.TotalCount,
            recordsFiltered = result.FilteredCount,
            data = result
        });
    }

    protected DataTableQueryOption BuildDataTableQueryOption(DataTableModel model, string defaultColumnName)
    {
        return _builder.BuildOption(model, defaultColumnName);
    }
}