namespace Olbrasoft.Blog.Data.Commands;

public abstract class BlogCommand : BlogCommand<bool>
{

    protected BlogCommand(ICommandExecutor executor) : base(executor)
    {
    }

    protected BlogCommand(IMediator mediator) : base(mediator)
    {
    }
}


public abstract class BlogCommand<TResult> : BaseCommand<TResult>
{
    public int Id { get; set; }
    public int CreatorId { get; set; }

    protected BlogCommand(ICommandExecutor executor) : base(executor)
    {
    }

    protected BlogCommand(IMediator mediator) : base(mediator)
    {
    }
}