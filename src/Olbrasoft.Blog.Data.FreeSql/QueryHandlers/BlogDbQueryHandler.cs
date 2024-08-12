namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers;

public abstract class BlogDbQueryHandler<TEntity, TQuery, TResult> : DbQueryHandler<BlogFreeSqlDbContext, TEntity, TQuery, TResult> where TQuery : BaseQuery<TResult> where TEntity : class
{
    protected BlogDbQueryHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }


    public override Task<TResult> Handle(TQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);
        return GetResultToHandleAsync(query, token);
    }

    protected abstract Task<TResult> GetResultToHandleAsync(TQuery query, CancellationToken token);
}


public abstract class BlogDbQueryHandler<TEntity, TQuery> : BlogDbQueryHandler<TEntity, TQuery, bool> where TQuery : BaseQuery<bool> where TEntity : class
{
    protected BlogDbQueryHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }


}