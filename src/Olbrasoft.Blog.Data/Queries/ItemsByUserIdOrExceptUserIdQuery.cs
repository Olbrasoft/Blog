using Olbrasoft.Data.Cqrs;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries
{
    public class ItemsByUserIdOrExceptUserIdQuery<TResult> : DataTablesPagedQuery<TResult>
    {
        public ItemsByUserIdOrExceptUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int UserIdOrExceptUserId { get; set; }

        public bool ExceptUser { get; set; }
    }
}