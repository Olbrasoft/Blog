namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers;

public class PostByIdQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Post, PostByIdQuery, PostEditDto>(projector, context)
{
    protected override async Task<PostEditDto> GetResultToHandleAsync(PostByIdQuery query, CancellationToken token)
        => await ProjectTo<PostEditDto>(p => p.Id == query.Id).FirstAsync(token);
}