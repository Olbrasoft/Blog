using Microsoft.EntityFrameworkCore;
using Olbrasoft.Dispatching.Common;
using Olbrasoft.Mapping;
using System.Linq;

namespace Olbrasoft.Data.Cqrs.EntityFrameworkCore
{
    public abstract class DbQueryHandler<TEntity, TQuery, TResult> : QueryHandler<TQuery, TResult> where TQuery : IRequest<TResult> where TEntity : class
    {
        protected readonly DbContext Context;

        protected readonly IQueryable<TEntity> Entities;

        protected DbQueryHandler(IProjector projector, DbContext context) : base(projector)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }
    }

    public abstract class DbQueryHandler<TEntity, TQuery> : QueryHandler<TQuery> where TQuery : IRequest<bool> where TEntity : class
    {
        protected readonly DbContext Context;

        protected readonly IQueryable<TEntity> Entities;

        protected DbQueryHandler(DbContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }
    }
}