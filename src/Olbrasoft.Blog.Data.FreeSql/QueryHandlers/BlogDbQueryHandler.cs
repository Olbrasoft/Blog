namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers;

public abstract class BlogDbQueryHandler<TEntity, TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : BaseQuery<TResult> where TEntity : class
{
    protected ISelect<TEntity> Select { get; set; }
    
    protected BlogDbQueryHandler(IDbSetProvider setProvider)
    {
        if (setProvider is null)
            throw new ArgumentNullException(nameof(setProvider));

        Select = setProvider.Set<TEntity>().Select;
    }

   protected BlogDbQueryHandler(IDataSelector selector)
   {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        Select = selector.Select<TEntity>();
   }

    public abstract Task<TResult> HandleAsync(TQuery query, CancellationToken token);

    protected static void ThrowIfQueryIsNullOrCancellationRequested(TQuery query, CancellationToken token)
    {
        if (query is null)
            throw new ArgumentNullException(nameof(query));
        
        token.ThrowIfCancellationRequested();
    }
}

public abstract class BlogDbQueryHandler<TEntity, TQuery> : BlogDbQueryHandler<TEntity, TQuery, bool> where TQuery : BaseQuery<bool> where TEntity : class
{
    protected BlogDbQueryHandler(IDbSetProvider setOwner) : base(setOwner)
    {
    }
}