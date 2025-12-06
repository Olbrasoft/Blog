namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers;

public abstract class BlogDbCommandHandler<TCommand, TEntity> : DbCommandHandler<BlogFreeSqlDbContext, TEntity, TCommand, bool>
    where TCommand : BaseCommand<bool> where TEntity : class
{
    protected BlogDbCommandHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected BlogDbCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    public override Task<bool> HandleAsync(TCommand command, CancellationToken token)
    {
        ThrowIfCommandIsNullOrCancellationRequested(command, token);

        return GetResultToHandleAsync(command, token);
    }

    protected abstract Task<bool> GetResultToHandleAsync(TCommand command, CancellationToken token);

}

public abstract class BlogDbCommandHandler<TCommand, TEntity, TResult> : DbCommandHandler<BlogFreeSqlDbContext, TEntity, TCommand, TResult>
    where TCommand : BaseCommand<TResult> where TEntity : class
{
    protected BlogDbCommandHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected BlogDbCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    public override Task<TResult> HandleAsync(TCommand command, CancellationToken token)
    {
        ThrowIfCommandIsNullOrCancellationRequested(command, token);

        return GetResultToHandleAsync(command, token);
    }

    protected abstract Task<TResult> GetResultToHandleAsync(TCommand command, CancellationToken token);

}
