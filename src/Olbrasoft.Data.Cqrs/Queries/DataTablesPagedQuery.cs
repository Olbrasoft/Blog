using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Data.Cqrs.Queries
{
    public abstract class DataTablesPagedQuery<TResult> : PagedQuery<TResult>
    {
        protected DataTablesPagedQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        protected DataTablesPagedQuery(IRequestHandler<Request<TResult>, TResult> handler) : base(handler)
        {
        }

        public OrderDirection OrderByDirection { get; set; }

        public string OrderByColumnName { get; set; }

        public string Search { get; set; }
    }
}