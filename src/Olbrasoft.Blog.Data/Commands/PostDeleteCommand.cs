namespace Olbrasoft.Blog.Data.Commands;
public class PostDeleteCommand : BlogCommand
{
       

    public PostDeleteCommand(ICommandExecutor executor) : base(executor)
    {
    }

    public PostDeleteCommand(IMediator mediator) : base(mediator)
    {
    }
}
