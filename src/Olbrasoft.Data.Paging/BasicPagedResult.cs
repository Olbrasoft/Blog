using System.Collections.Generic;

namespace Olbrasoft.Data.Paging
{
    public class BasicPagedResult<TRecord> : IBasicPagedResult<TRecord>
    {
        public IEnumerable<TRecord> Records { get; set; }

        public int TotalCount { get; set; }
    }
}