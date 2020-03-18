using Microsoft.AspNetCore.Mvc;

namespace Olbrasoft.Data.Paging.DataTables
{
    public interface IDataTableBuilder
    {
        DataTableQueryOption BuildOption(DataTableModel model, string defaultColumnName);

        JsonResult BuildJson<TRecord>(IPagedResult<TRecord> result);
    }
}