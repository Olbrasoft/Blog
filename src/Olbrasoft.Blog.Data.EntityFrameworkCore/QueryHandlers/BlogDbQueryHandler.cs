namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers;

/// <summary>
/// Represents a base class for query handlers in the BlogDbContext using Entity Framework Core.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TQuery">The type of the query.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
public abstract class BlogDbQueryHandler<TEntity, TQuery, TResult> : DbQueryHandler<BlogDbContext, TEntity, TQuery, TResult> where TQuery : BaseQuery<TResult> where TEntity : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BlogDbQueryHandler{TEntity, TQuery, TResult}"/> class.
    /// </summary>
    /// <param name="context">The BlogDbContext.</param>
    protected BlogDbQueryHandler(BlogDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BlogDbQueryHandler{TEntity, TQuery, TResult}"/> class.
    /// </summary>
    /// <param name="projector">The projector.</param>
    /// <param name="context">The BlogDbContext.</param>
    protected BlogDbQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }

    /// <summary>
    /// Handles the query asynchronously.
    /// </summary>
    /// <param name="query">The query to handle.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation and contains the result of the query.</returns>
    public override Task<TResult> HandleAsync(TQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);
        return GetResultToHandleAsync(query, token);
    }

    /// <summary>
    /// Gets the result to handle asynchronously.
    /// </summary>
    /// <param name="query">The query to handle.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation and contains the result of the query.</returns>
    protected abstract Task<TResult> GetResultToHandleAsync(TQuery query, CancellationToken token);
}

/// <summary>
/// Represents a base class for query handlers in the BlogDbContext using Entity Framework Core.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TQuery">The type of the query.</typeparam>
public abstract class BlogDbQueryHandler<TEntity, TQuery> : BlogDbQueryHandler<TEntity, TQuery, bool> where TQuery : BaseQuery<bool> where TEntity : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BlogDbQueryHandler{TEntity, TQuery}"/> class.
    /// </summary>
    /// <param name="projector">The projector.</param>
    /// <param name="context">The BlogDbContext.</param>
    protected BlogDbQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }
}