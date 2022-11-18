namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers;
public abstract class BlogDbCommandHandler<TCommand, TEntity> : DbCommandHandler<BlogDbContext, TEntity, TCommand, bool>
    where TCommand : BaseCommand<bool> where TEntity : class
{
    protected BlogDbCommandHandler(BlogDbContext context) : base(context)
    {
    }

    protected BlogDbCommandHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }

    protected BlogDbCommandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
    {
    }

    protected BlogDbCommandHandler(IProjector projector, IMapper mapper, BlogDbContext context) : base(projector, mapper, context)
    {
    }

    public override Task<bool> HandleAsync(TCommand command, CancellationToken token)
    {
        ThrowIfCommandIsNullOrCancellationRequested(command, token);

        return GetResultToHandleAsync(command, token);
    }

    protected abstract Task<bool> GetResultToHandleAsync(TCommand command, CancellationToken token);
}
