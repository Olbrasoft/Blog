namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers
{
    public class PostDetailByIdQueryHandler : BlogDbQueryHandler<Post, PostDetailByIdQuery, PostDetailDto>
    {
        public PostDetailByIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<PostDetailDto> HandleAsync(PostDetailByIdQuery request, CancellationToken token)
        {
            return await ProjectTo<PostDetailDto>(EntityQueryable.Where(p => p.Id == request.Id)).FirstAsync(token);
        }
    }
}