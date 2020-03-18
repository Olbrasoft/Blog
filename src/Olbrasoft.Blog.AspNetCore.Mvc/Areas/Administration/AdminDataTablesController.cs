using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Data.Paging;
using Olbrasoft.Data.Paging.DataTables;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Controllers
{
    public class AdminDataTablesController : AdminController
    {
        private readonly IDataTableBuilder _builder;

        public AdminDataTablesController(IDataTableBuilder builder)
        {
            _builder = builder;
        }

        protected JsonResult BuildDataTableJson<T>(IPagedResult<T> result)
        {
            return _builder.BuildJson(result);
        }

        protected DataTableQueryOption BuildDataTableQueryOption(DataTableModel model, string defaultColumnName)
        {
            return _builder.BuildOption(model, defaultColumnName);
        }
    }
}