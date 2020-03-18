using Microsoft.EntityFrameworkCore;
using Olbrasoft.Dispatching;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Olbrasoft.Data.Cqrs.EntityFrameworkCore
{
    public abstract class QueryHandler<TEntity, TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IRequest<TResult> where TEntity : class
    {
        protected readonly DbContext Context;

        protected readonly IQueryable<TEntity> Entities;

        protected QueryHandler(DbContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }

        public abstract Task<TResult> HandleAsync(TQuery query, CancellationToken token);
    }
}