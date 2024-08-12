using Olbrasoft.Blog.Data.Commands.TagCommands;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers;
public class TagDeleteCommandHandler : BlogDbCommandHandler<TagDeleteCommand, Tag>
{
    public TagDeleteCommandHandler(BlogDbContext context) : base(context)
    {
    }

    protected override async Task<bool> GetResultToHandleAsync(TagDeleteCommand command, CancellationToken token)
    {
        var tagForDelete = await GetOneOrNullAsync(tag => tag.Id == command.Id && tag.CreatorId == command.CreatorId, token);

        if (tagForDelete != null)
            Entities.Remove(tagForDelete);

        return await SaveOneEntityAsync(token);
    }
}
