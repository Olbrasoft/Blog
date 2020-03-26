namespace Olbrasoft.Data.Paging.DataTables
{
    public class DataTableQueryOption
    {
        public string Search { get; set; }

        public IPageInfo Paging { get; set; }

        public OrderDirection Direction { get; set; }

        public string Column { get; set; }
    }
}