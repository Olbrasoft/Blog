namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers;

public class PostByIdQueryHandler : BlogDbQueryHandler<Post, PostByIdQuery, PostEditDto>
{
    public PostByIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }

    protected override async Task<PostEditDto> GetResultToHandleAsync(PostByIdQuery query, CancellationToken token)
    {
        return await ProjectTo<PostEditDto>(Queryable.Where(p => p.Id == query.Id)).FirstAsync(token);
    }
}