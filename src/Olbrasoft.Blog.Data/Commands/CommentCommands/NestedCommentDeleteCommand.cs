namespace Olbrasoft.Blog.Data.Commands.CommentCommands;

public class NestedCommentDeleteCommand : ByIdAndCreatorIdRequest
{
    public NestedCommentDeleteCommand(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}