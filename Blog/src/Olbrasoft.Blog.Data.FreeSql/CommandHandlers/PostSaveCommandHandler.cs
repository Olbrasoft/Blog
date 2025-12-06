namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers;

public class PostSaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : BlogDbCommandHandler<PostSaveCommand, Post, int>(mapper, context)
{
    protected override async Task<int> GetResultToHandleAsync(PostSaveCommand command, CancellationToken token)
    {
        var post = MapCommandToNewEntity(command);

        await Entities.AddOrUpdateAsync(post, token);

        if (command.TagIds.Any() && command.CreatorId > 0)
        {
            post.Tags = command.TagIds.Select(tagId => new Tag { Id = tagId }).ToList();
        }

        _ = await SaveAsync(post, token);

        return post.Id;
    }
}
