namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.TagCommandHandlers;
public class TagDeleteCommandHandler(BlogFreeSqlDbContext context) : BlogDbCommandHandler<TagDeleteCommand, Tag>(context)
{
    protected override async Task<bool> GetResultToHandleAsync(TagDeleteCommand command, CancellationToken token)
    {
        return await DeleteAsync(t => t.Id == command.Id && t.CreatorId == command.CreatorId, token) == 1;
    }
}
