﻿using Olbrasoft.Data.Cqrs.Queries;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries
{
    public abstract class ItemsByUserIdQuery<TResult> : DataTablesPagedQuery<TResult>
    {
        protected ItemsByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int UserId { get; set; }
    }
}