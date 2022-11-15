namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers
{
    public abstract class BlogDbQueryHandler<TEntity, TQuery, TResult> : IRequestHandler<TQuery,TResult>  where TQuery : BaseQuery<TResult> where TEntity : class
    {
        private readonly IProjector _projector;
        protected BlogDbContext Context { get; private set; }
        protected IQueryable<TEntity> EntityQueryable { get; set; }

        protected BlogDbQueryHandler(IProjector projector, BlogDbContext context) 
        {
            _projector = projector;

            Context = context ?? throw new ArgumentNullException(nameof(context));
            EntityQueryable ??= Context.Set<TEntity>();
        }

        protected IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            return source is null
                ? throw new ArgumentNullException(nameof(source))
                : _projector.ProjectTo<TDestination>(source);
        }

        public abstract Task<TResult> HandleAsync(TQuery request, CancellationToken token);

        protected static void ThrowIfQueryIsNullOrCancellationRequested(TQuery query, CancellationToken token)
        {
            if (query is null)
                throw new ArgumentNullException(nameof(query));

            token.ThrowIfCancellationRequested();
        }

    }

    public abstract class BlogDbQueryHandler<TEntity, TQuery> : BlogDbQueryHandler<TEntity, TQuery, bool> where TQuery : BaseQuery<bool> where TEntity : class
    {
        protected BlogDbQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }
    }
}