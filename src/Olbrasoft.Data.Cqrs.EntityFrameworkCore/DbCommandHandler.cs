using Microsoft.EntityFrameworkCore;
using Olbrasoft.Dispatching;
using Olbrasoft.Mapping;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Cqrs.EntityFrameworkCore
{
    public abstract class DbCommandHandler<TEntity, TCommand> : CommandHandler<TCommand> where TCommand : Request<bool> where TEntity : class
    {
        protected readonly DbContext Context;

        protected readonly DbSet<TEntity> Set;

        public DbCommandHandler(IMapper mapper, DbContext context) : base(mapper)
        {
            Context = context;
            Set = Context.Set<TEntity>();
        }

        protected async Task<int> SaveAsyc(CancellationToken token) => await Context.SaveChangesAsync(token);
    }
}