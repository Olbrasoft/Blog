namespace Olbrasoft.Blog.Data.Commands.CommentCommands;

public class NestedCommentDeleteCommand : BlogCommand
{ 
    public NestedCommentDeleteCommand(ICommandExecutor executor) : base(executor)
    {
    }

    public NestedCommentDeleteCommand(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}