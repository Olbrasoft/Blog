﻿using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.TagQueries
{
    public class TagsByExceptUserIdQuery : ItemsExceptUserIdQuery<IPagedResult<TagOfUsersDto>>
    {
        public TagsByExceptUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}