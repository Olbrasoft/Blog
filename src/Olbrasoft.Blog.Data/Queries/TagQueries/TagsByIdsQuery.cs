﻿using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Dispatching;
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