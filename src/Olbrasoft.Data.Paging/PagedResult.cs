namespace Olbrasoft.Data.Paging
{
    public class PagedResult<TRecord> : BasicPagedResult<TRecord>, IPagedResult<TRecord>
    {
        public int FilteredCount { get; set; }
    }
}