namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers;

public abstract class BlogDbCommandHandler<TCommand, TEntity> : DbCommandHandler<BlogFreeSqlDbContext,TEntity,TCommand, bool>
    where TCommand : BaseCommand<bool> where TEntity : class
{
    protected BlogDbCommandHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected BlogDbCommandHandler(IConfigure<TEntity> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    protected BlogDbCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    protected BlogDbCommandHandler(IMapper mapper, IConfigure<TEntity> configurator, BlogFreeSqlDbContext context) : base(mapper, configurator, context)
    {
    }
}
