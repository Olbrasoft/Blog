﻿using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Dispatching;
using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.Queries.TagQueries
{
    public class TagsWhereLabelContainsTextQuery : Request<IEnumerable<TagDto>>
    {
        public TagsWhereLabelContainsTextQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public IEnumerable<int> ExceptTagIds { get; set; }
        public string Text { get; set; }
    }
}