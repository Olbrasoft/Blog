namespace Olbrasoft.Blog.Data.Commands.CommentCommands;

public class NestedCommentDeleteCommand : BlogCommand
{ 
    public NestedCommentDeleteCommand(ICommandExecutor executor) : base(executor)
    {
    }

    public NestedCommentDeleteCommand(IMediator mediator) : base(mediator)
    {
    }
}