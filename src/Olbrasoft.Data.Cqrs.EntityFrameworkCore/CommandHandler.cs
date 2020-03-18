using Microsoft.EntityFrameworkCore;
using Olbrasoft.Dispatching;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Cqrs.EntityFrameworkCore
{
    public abstract class CommandHandler<TEntity, TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : Request<TResult> where TEntity : class
    {
        protected readonly DbContext Context;

        protected readonly DbSet<TEntity> Set;

        protected CommandHandler(DbContext context)
        {
            Context = context;
            Set = Context.Set<TEntity>();
        }

        protected async Task<int> SaveAsyc(CancellationToken token)
        {
            return await Context.SaveChangesAsync(token);
        }

        public abstract Task<TResult> HandleAsync(TCommand command, CancellationToken token);
    }
}