namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostByIdQueryHandler : BlogDbQueryHandler<Post, PostByIdQuery, PostEditDto>
{
    private readonly IMapper _mapper;

    public PostByIdQueryHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(context)
    {
        _mapper = mapper;
    }

    protected override async Task<PostEditDto> GetResultToHandleAsync(PostByIdQuery query, CancellationToken token)
    {
        var post = await Select.Where(p => p.Id == query.Id).IncludeMany(p => p.Tags).FirstAsync(token);

        var postEditDto = _mapper.MapTo<PostEditDto>(post);

        return postEditDto;
    }
}