namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers;

public class PostByIdQueryHandler : BlogDbQueryHandler<Post, PostByIdQuery, PostEditDto>
{
    public PostByIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
    {
    }

    public override async Task<PostEditDto> HandleAsync(PostByIdQuery query, CancellationToken token)
    {
        return await ProjectTo<PostEditDto>(Entities.Where(p => p.Id == query.Id)).FirstAsync(token);
    }
}