using Olbrasoft.Data.Cqrs.FreeSql;

namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostDetailByIdQueryHandler : BlogDbQueryHandler<Post, PostDetailByIdQuery, PostDetailDto>
{
    private readonly IMapper _mapper;

    public PostDetailByIdQueryHandler(IMapper mapper, IConfigure<Post> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public override async Task<PostDetailDto> HandleAsync(PostDetailByIdQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);

        var posts = await Select.Where(p => p.Id == query.Id)
                                .Include(p=>p.Category)    
                                .Include(p => p.Creator)
                                .IncludeMany(p => p.Tags)
                                .FirstAsync(token);

        return _mapper.MapTo<PostDetailDto>(posts);
    }
}