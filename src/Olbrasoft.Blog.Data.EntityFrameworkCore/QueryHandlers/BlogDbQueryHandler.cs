namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers
{
    public abstract class BlogDbQueryHandler<TEntity, TQuery, TResult> : IRequestHandler<TQuery,TResult>  where TQuery : BaseQuery<TResult> where TEntity : class
    {
        private readonly IProjector _projector;
        protected BlogDbContext Context { get; private set; }
        protected IQueryable<TEntity> Entities { get; private set; }


        protected BlogDbQueryHandler(IProjector projector, BlogDbContext context) 
        {
            _projector = projector;

            Context = context ?? throw new ArgumentNullException(nameof(context));
            Entities ??= Context.Set<TEntity>();
        }

        protected IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            return source is null
                ? throw new ArgumentNullException(nameof(source))
                : _projector.ProjectTo<TDestination>(source);
        }

        public abstract Task<TResult> HandleAsync(TQuery request, CancellationToken token);
       
    }

    public abstract class BlogDbQueryHandler<TEntity, TQuery> : IRequestHandler<TQuery, bool> where TQuery : BaseQuery<bool> where TEntity : class
    {

        protected BlogDbContext Context { get; private set; }
        protected IQueryable<TEntity> Entities { get; private set; }

        protected BlogDbQueryHandler(BlogDbContext context) 
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Entities ??= Context.Set<TEntity>();
        }

        public abstract Task<bool> HandleAsync(TQuery request, CancellationToken token);
       
    }
}