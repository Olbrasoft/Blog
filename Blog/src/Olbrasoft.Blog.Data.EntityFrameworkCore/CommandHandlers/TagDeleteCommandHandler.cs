namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers;
public class TagDeleteCommandHandler(BlogDbContext context) : BlogDbCommandHandler<TagDeleteCommand, Tag>(context)
{


    protected override async Task<bool> GetResultToHandleAsync(TagDeleteCommand command, CancellationToken token)
        => command.CreatorId == 0
            ? await DeleteAsync(new Tag { Id = command.Id }, token) == 1
            : await DeleteAsync(tag => tag.Id == command.Id && tag.CreatorId == command.CreatorId, token) == 1;
}
