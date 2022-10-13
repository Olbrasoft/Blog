namespace Olbrasoft.Blog.Data.Commands;

public class TagSaveCommand : BlogCommand
{
    public TagSaveCommand(ICommandExecutor executor) : base(executor)
    {
    }

    public TagSaveCommand(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public string Label { get; set; } = string.Empty;
}