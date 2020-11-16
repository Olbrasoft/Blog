using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Dispatching.Common;
using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.Queries.TagQueries
{
    public class TagsByIdsQuery : Request<IEnumerable<TagSmallDto>>
    {
        public TagsByIdsQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public IEnumerable<int> Ids { get; set; }
    }
}