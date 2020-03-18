﻿using Olbrasoft.Dispatching;
using Olbrasoft.Paging;

namespace Olbrasoft.Data.Cqrs
{
    public abstract class PagedQuery<TResult> : Request<TResult>
    {
        public PagedQuery(IRequestHandler<Request<TResult>, TResult> handler) : base(handler)
        {
        }

        public PagedQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public IPageInfo Paging { get; set; } = new PageInfo();
    }
}