using Olbrasoft.Data.Paging;
using System;
using X.PagedList;

namespace Olbrasoft.Paging.X.PagedList
{
    public static class ResultExtensions
    {
        public static IPagedList<T> AsPagedList<T>(this IPagedResult<T> source, IPageInfo pageInfo)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pageInfo == null) throw new ArgumentNullException(nameof(pageInfo));

            return new SimplePagedList<T>(source.Records, pageInfo.NumberOfSelectedPage, pageInfo.PageSize, source.TotalCount);
        }
    }
}