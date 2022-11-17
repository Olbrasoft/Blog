namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers;

public class PostSaveCommandHandler : BlogDbCommandHandler<PostSaveCommand, Post>
{
    public PostSaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    protected override async Task<bool> GetResultToHandleAsync(PostSaveCommand command, CancellationToken token)
    {
       
        var post = MapTo<Post>(command);

        await Entities.AddOrUpdateAsync(post, token);

        if (command.TagIds.Any() && command.CreatorId > 0)
        {
            post.Tags = command.TagIds.Select(tagId => new Tag { Id = tagId }).ToList();

            await Entities.AddOrUpdateAsync(post, token);
        }

        return await SaveOneEntityAsync(token);
    }
}
