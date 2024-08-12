namespace Olbrasoft.Blog.Data.Commands.CommentCommands;

public class CommentSaveCommand : BlogCommand
{
    public CommentSaveCommand(ICommandExecutor executor) : base(executor)
    {
    }

    public CommentSaveCommand(IMediator mediator) : base(mediator)
    {
    }

    public int PostId { get; set; }

    public string Text { get; set; } = string.Empty;
}