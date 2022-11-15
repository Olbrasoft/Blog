using System.Linq.Expressions;

namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers;

public abstract class BlogDbCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, bool>
    where TCommand : BaseCommand<bool> where TEntity : class
{
    private readonly IMapper _mapper;

    private readonly IDbContextProxy _proxy;

    protected DbSet<TEntity> Entities { get; private set; }

    protected BlogDbCommandHandler(IMapper mapper, IDbContextProxy proxy)
    {
        _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        Entities = _proxy.Set<TEntity>();
    }

    public abstract Task<bool> HandleAsync(TCommand command, CancellationToken token);

    protected ISelect<TForeignEntity> Select<TForeignEntity>() where TForeignEntity : class
        => _proxy.Set<TForeignEntity>().Select;

    protected Task RemoveAsync<TForeignEntity>(Expression<Func<TForeignEntity, bool>> predicate) where TForeignEntity : class 
        => _proxy.Set<TForeignEntity>().RemoveAsync(predicate);

    protected DbSet<TForeignEntity> Set<TForeignEntity>() where TForeignEntity:class
        => _proxy.Set<TForeignEntity>();

    protected async Task<bool> SaveChangesAsync(CancellationToken token) => await _proxy.SaveChangesAsync(token) == 1;

    protected TDestination MapTo<TDestination>(object source) => _mapper.MapTo<TDestination>(source);

    protected static void ThrowIfCommandIsNullOrCancellationRequested(TCommand command, CancellationToken token)
    {
        if (command is null)
            throw new ArgumentNullException(nameof(command));

        token.ThrowIfCancellationRequested();
    }
}
