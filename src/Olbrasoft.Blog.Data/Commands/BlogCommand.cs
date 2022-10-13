namespace Olbrasoft.Blog.Data.Commands;

public abstract class BlogCommand : BaseCommand<bool>
{
    public int Id { get; set; }
    public int CreatorId { get; set; }

    protected BlogCommand(ICommandExecutor executor) : base(executor)
    {
    }

    protected BlogCommand(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}