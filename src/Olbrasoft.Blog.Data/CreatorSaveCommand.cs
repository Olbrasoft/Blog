using Olbrasoft.Data.Cqrs;
using Olbrasoft.Data.Cqrs.Requests;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data
{
    public abstract class CreatorSaveCommand : ByIdRequest
    {
        public CreatorSaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int CreatorId { get; set; }
    }
}