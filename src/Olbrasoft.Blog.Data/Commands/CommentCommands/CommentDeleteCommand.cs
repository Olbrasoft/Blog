using Olbrasoft.Data.Cqrs;
using Olbrasoft.Data.Cqrs.Requests;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Commands.CommentCommands
{
    public class CommentDeleteCommand : ByIdAndCreatorIdRequest
    {
        public CommentDeleteCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}