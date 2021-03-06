﻿using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Data.Cqrs.Queries;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.PostQueries
{
    public class PostsPagedQuery : PagedQuery<IBasicPagedResult<PostDto>>
    {
        public PostsPagedQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public string Search { get; set; }
    }
}