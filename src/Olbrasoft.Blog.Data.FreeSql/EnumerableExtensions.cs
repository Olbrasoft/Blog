namespace Olbrasoft.Blog.Data.FreeSql;
public static class EnumerableExtensions
{
    public static IPagedResult<T> AsPagedResult<T>(this IEnumerable<T> items, long totalCount, long filteredCount)
    {
        return Extensions.Paging.EnumerableExtensions.AsPagedResult(items, (int)totalCount, (int)filteredCount);
    }

    public static IPagedEnumerable<T> AsPagedEnumerable<T>(this IEnumerable<T> items, long totalCount)
    {
        return Extensions.Paging.EnumerableExtensions.AsPagedEnumerable(items, (int)totalCount);
    }
}