﻿using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.PostQueries
{
    public class PostsByUserIdQuery : ItemsByUserIdQuery<IPagedResult<PostOfUserDto>>
    {
        public PostsByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}