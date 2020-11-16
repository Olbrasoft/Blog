using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Data.Cqrs.Queries
{
    public abstract class ByIdQuery<TResult> : Request<TResult>
    {
        protected ByIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        protected ByIdQuery(IRequestHandler<Request<TResult>, TResult> handler) : base(handler)
        {
        }

        public int Id { get; set; }
    }
}