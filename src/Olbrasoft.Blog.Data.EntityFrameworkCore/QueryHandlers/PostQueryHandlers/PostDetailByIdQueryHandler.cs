namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers
{
    public class PostDetailByIdQueryHandler : BlogDbQueryHandler<Post, PostDetailByIdQuery, PostDetailDto>
    {
        public PostDetailByIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        protected override async Task<PostDetailDto> GetResultToHandleAsync(PostDetailByIdQuery request, CancellationToken token)
        {
            return await ProjectTo<PostDetailDto>(Queryable.Where(p => p.Id == request.Id)).FirstAsync(token);
        }
    }
}