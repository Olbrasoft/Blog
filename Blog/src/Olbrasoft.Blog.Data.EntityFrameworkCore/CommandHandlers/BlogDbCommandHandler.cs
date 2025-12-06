using Olbrasoft.Data.Entities.Abstractions;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers;


public abstract class BlogDbCommandHandler<TCommand, TEntity> : DbBaseCommandHandler<BlogDbContext, TEntity, TCommand, bool>
    where TCommand : ICommand<bool> where TEntity : BaseEnity
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


public abstract class BlogDbCommandHandler<TCommand, TEntity, TResult> : DbBaseCommandHandler<BlogDbContext, TEntity, TCommand, TResult>
     where TCommand : ICommand<TResult> where TEntity : BaseEnity
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


    public override Task<TResult> HandleAsync(TCommand command, CancellationToken token)
    {
        ThrowIfCommandIsNullOrCancellationRequested(command, token);

        return GetResultToHandleAsync(command, token);
    }

    protected abstract Task<TResult> GetResultToHandleAsync(TCommand command, CancellationToken token);
}

