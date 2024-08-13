namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostDetailByIdQueryHandler(IEntityToDtoConfiguration<Post, PostDetailDto> postToPostDetailDtoConfiguration, BlogFreeSqlDbContext context) : BlogDbQueryHandler<Post, PostDetailByIdQuery, PostDetailDto>(context)
{
    private readonly IEntityToDtoConfiguration<Post, PostDetailDto> postToPostDetailDtoConfiguration = postToPostDetailDtoConfiguration ?? throw new ArgumentNullException(nameof(postToPostDetailDtoConfiguration));

    protected override async Task<PostDetailDto> GetResultToHandleAsync(PostDetailByIdQuery query, CancellationToken token)
    {
        var post = await GetOneOrNullAsync<PostDetailDto>(p => p.Id == query.Id,postToPostDetailDtoConfiguration.Configure(), token);

        post.Tags = await Context.Orm.Select<PostToTag, Tag>().InnerJoin((ptt, t) => ptt.ToId == t.Id && ptt.Id == query.Id)
             .ToListAsync((ptt, t) => new TagSmallDto { Id = t.Id, Label = t.Label }, token);

        return post;
    }
}