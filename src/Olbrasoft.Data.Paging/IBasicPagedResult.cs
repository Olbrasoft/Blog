using System.Collections.Generic;

namespace Olbrasoft.Data.Paging
{
    public interface IBasicPagedResult<out TRecord>
    {
        IEnumerable<TRecord> Records { get; }
        int TotalCount { get; }
    }
}