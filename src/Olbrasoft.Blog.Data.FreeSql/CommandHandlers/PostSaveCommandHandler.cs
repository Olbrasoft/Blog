namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers;

public class PostSaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : BlogDbCommandHandler<PostSaveCommand, Post>(mapper, context)
{
    protected override async Task<bool> GetResultToHandleAsync(PostSaveCommand command, CancellationToken token)
    {
        var post = MapCommandToNewEntity(command);

        await Entities.AddOrUpdateAsync(post, token);

        if (command.TagIds.Any() && command.CreatorId > 0)
        {
            post.Tags = command.TagIds.Select(tagId => new Tag { Id = tagId }).ToList();
        }

        return await SaveAsync(post, token) > 0;
    }
}
