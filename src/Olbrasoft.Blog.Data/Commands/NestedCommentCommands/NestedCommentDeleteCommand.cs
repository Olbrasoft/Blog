using Olbrasoft.Data.Cqrs;
using Olbrasoft.Data.Cqrs.Requests;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Commands.NestedCommentCommands
{
    public class NestedCommentDeleteCommand : ByIdAndCreatorIdRequest
    {
        public NestedCommentDeleteCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}