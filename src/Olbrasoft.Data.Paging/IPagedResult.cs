namespace Olbrasoft.Data.Paging
{
    public interface IPagedResult<out T> : IBasicPagedResult<T>
    {
        int FilteredCount { get; }
    }
}