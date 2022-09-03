using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Dispatching;
using Olbrasoft.Mapping;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers
{
    public abstract class BlogDbQueryHandler<TEntity, TQuery, TResult> : DbQueryHandler<TQuery, TResult, BlogDbContext, TEntity> where TQuery : IRequest<TResult> where TEntity : class
    {
        protected BlogDbQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }
    }

    public abstract class BlogDbQueryHandler<TEntity, TQuery> : DbQueryHandler<TQuery, BlogDbContext, TEntity> where TQuery : IRequest<bool> where TEntity : class
    {
        protected BlogDbQueryHandler(BlogDbContext context) : base(context)
        {
        }
    }
}