namespace Olbrasoft.Blog.Data.Commands.CommentCommands;

public class NestedCommentSaveCommand : BlogCommand
{
    public NestedCommentSaveCommand(ICommandExecutor executor) : base(executor)
    {
    }

    public NestedCommentSaveCommand(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public int CommentId { get; set; }

    public string Text { get; set; } = string.Empty;
}