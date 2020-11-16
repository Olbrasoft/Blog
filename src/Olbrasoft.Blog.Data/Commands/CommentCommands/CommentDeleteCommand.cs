using Olbrasoft.Data.Cqrs;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Commands.CommentCommands
{
    public class CommentDeleteCommand : DeleteCommand
    {
        public CommentDeleteCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}