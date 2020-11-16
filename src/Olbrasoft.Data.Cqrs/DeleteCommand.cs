using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Data.Cqrs
{
    public class DeleteCommand : Request<bool>
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }

        public DeleteCommand(IRequestHandler<Request<bool>, bool> handler) : base(handler)
        {
        }

        public DeleteCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}