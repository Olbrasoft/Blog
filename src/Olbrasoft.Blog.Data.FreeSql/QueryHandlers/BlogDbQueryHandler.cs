using Olbrasoft.Data.Cqrs.FreeSql;

namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers;

public abstract class BlogDbQueryHandler<TEntity, TQuery, TResult> : DbQueryHandler<BlogFreeSqlDbContext, TEntity, TQuery, TResult> where TQuery : BaseQuery<TResult> where TEntity : class
{
    protected BlogDbQueryHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected BlogDbQueryHandler(IConfigure<TEntity> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

}


public abstract class BlogDbQueryHandler<TEntity, TQuery> : BlogDbQueryHandler<TEntity, TQuery, bool> where TQuery : BaseQuery<bool> where TEntity : class
{
    protected BlogDbQueryHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected BlogDbQueryHandler(IConfigure<TEntity> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }
}