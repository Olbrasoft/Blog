namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.PostQueryHandlers;

public class PostDetailByIdQueryHandler : BlogDbQueryHandler<Post, PostDetailByIdQuery, PostDetailDto>
{
    public PostDetailByIdQueryHandler(IConfigure<Post> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    protected override async Task<PostDetailDto> GetResultToHandleAsync(PostDetailByIdQuery query, CancellationToken token)
    {
        var post = await GetOneOrNullAsync<PostDetailDto>(p => p.Id == query.Id, token);

        post.Tags = await Context.Orm.Select<PostToTag, Tag>().InnerJoin((ptt, t) => ptt.ToId == t.Id && ptt.Id == query.Id)
             .ToListAsync((ptt, t) => new TagSmallDto { Id = t.Id, Label = t.Label }, token);

        return post;
    }
}