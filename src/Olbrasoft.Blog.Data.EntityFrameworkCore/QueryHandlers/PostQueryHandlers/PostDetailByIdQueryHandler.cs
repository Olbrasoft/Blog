namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers;

public class PostDetailByIdQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Post, PostDetailByIdQuery, PostDetailDto>(projector, context)
{
    protected override async Task<PostDetailDto> GetResultToHandleAsync(PostDetailByIdQuery request, CancellationToken token)
        => await ProjectTo<PostDetailDto>(p => p.Id == request.Id).FirstAsync(token);
}