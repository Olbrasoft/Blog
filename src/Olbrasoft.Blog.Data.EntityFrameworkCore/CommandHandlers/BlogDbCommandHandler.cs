namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers;
public abstract class BlogDbCommandHandler<TCommand,  TEntity> : IRequestHandler<TCommand, bool> 
    where TCommand : BaseCommand<bool>  where TEntity : class
{
    private readonly IMapper _mapper;

    protected BlogDbContext Context { get; private set; }

    protected DbSet<TEntity> Entities { get; private set; }



    protected BlogDbCommandHandler(IMapper mapper, BlogDbContext context) 
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

         Entities = Context.Set<TEntity>();
    }

    protected TDestination MapTo<TDestination>(object source)
    {
       return _mapper.MapTo<TDestination>(source);
    }

    public abstract Task<bool> HandleAsync(TCommand request, CancellationToken token);
  
}
