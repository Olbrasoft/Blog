using Olbrasoft.Data.Cqrs.Queries;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.TagQueries
{
    public abstract class ItemsExceptUserIdQuery<TResult> : DataTablesPagedQuery<TResult>
    {
        protected ItemsExceptUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int ExceptUserId { get; set; }
    }
}