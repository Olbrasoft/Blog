namespace Olbrasoft.Blog.Data.Commands.CommentCommands;

public class CommentSaveCommand : BlogCommand
{
    public CommentSaveCommand(ICommandExecutor executor) : base(executor)
    {
    }

    public CommentSaveCommand(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public int PostId { get; set; }

    public string Text { get; set; } = string.Empty;
}