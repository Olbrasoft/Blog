namespace Olbrasoft.Blog.Data.Commands.CommentCommands;

public class CommentDeleteCommand : BlogCommand
{
    public CommentDeleteCommand(ICommandExecutor executor) : base(executor)
    {
    }

    public CommentDeleteCommand(IMediator mediator) : base(mediator)
    {
    }
}