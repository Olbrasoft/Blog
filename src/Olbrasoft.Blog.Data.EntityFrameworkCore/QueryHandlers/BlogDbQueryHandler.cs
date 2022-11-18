namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers
{
    public abstract class BlogDbQueryHandler<TEntity, TQuery, TResult> : DbQueryHandler<BlogDbContext, TEntity, TQuery, TResult> where TQuery : BaseQuery<TResult> where TEntity : class
    {
        protected BlogDbQueryHandler(BlogDbContext context) : base(context)
        {
        }

        protected BlogDbQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override Task<TResult> HandleAsync(TQuery query, CancellationToken token)
        {
            ThrowIfQueryIsNullOrCancellationRequested(query, token);
            return GetResultToHandleAsync(query, token);
        }

        protected abstract Task<TResult> GetResultToHandleAsync(TQuery query, CancellationToken token);
    }

    public abstract class BlogDbQueryHandler<TEntity, TQuery> : BlogDbQueryHandler<TEntity, TQuery, bool> where TQuery : BaseQuery<bool> where TEntity : class
    {
        protected BlogDbQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }
    }




}