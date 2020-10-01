using Olbrasoft.Data.Cqrs;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Commands.NestedCommentCommands
{
    public class NestedCommentDeleteCommand : DeleteCommand
    {
        public NestedCommentDeleteCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}