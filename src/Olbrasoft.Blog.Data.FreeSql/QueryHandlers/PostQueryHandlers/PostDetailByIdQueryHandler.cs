namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostDetailByIdQueryHandler : BlogDbQueryHandler<Post, PostDetailByIdQuery, PostDetailDto>
{
    public PostDetailByIdQueryHandler(BlogFreeSqlDbContext context) : base( context)
    {
    }

    public override async Task<PostDetailDto> HandleAsync(PostDetailByIdQuery request, CancellationToken token) 
        => await Select.Where(p => p.Id == request.Id)
            .FirstAsync(post => new PostDetailDto { Creator = post.Creator.FirstName + " " + post.Creator.LastName }, token);
}