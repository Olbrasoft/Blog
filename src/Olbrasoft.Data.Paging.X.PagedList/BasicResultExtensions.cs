using System;
using X.PagedList;

namespace Olbrasoft.Data.Paging.X.PagedList
{
    public static class BasicResultExtensions
    {
        public static IPagedList<T> AsPagedList<T>(this IBasicPagedResult<T> source, IPageInfo pageInfo)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pageInfo == null) throw new ArgumentNullException(nameof(pageInfo));

            return new SimplePagedList<T>(source.Records, pageInfo.NumberOfSelectedPage, pageInfo.PageSize, source.TotalCount);
        }
    }
}