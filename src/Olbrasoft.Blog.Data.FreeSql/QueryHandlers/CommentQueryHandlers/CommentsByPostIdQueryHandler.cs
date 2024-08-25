namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.CommentQueryHandlers;

public class CommentsByPostIdQueryHandler(IMapper mapper, BlogFreeSqlDbContext context) : BlogDbQueryHandler<Comment, CommentsByPostIdQuery, IEnumerable<CommentDto>>(context)
{
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    protected override async Task<IEnumerable<CommentDto>> GetResultToHandleAsync(CommentsByPostIdQuery query, CancellationToken token)
    {
        var result = await GetWhere(p => p.PostId == query.PostId)
            .Include(c => c.Creator)
            .IncludeMany(c => c.NestedComments, then => then.Include(nc => nc.Creator))
            .OrderByDescending(c => c.Created)
            .ToListAsync(token);

        return _mapper.MapTo<IEnumerable<CommentDto>>(result);
    }
}