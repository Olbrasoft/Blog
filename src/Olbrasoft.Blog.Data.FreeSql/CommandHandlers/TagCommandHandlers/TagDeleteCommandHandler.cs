namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.TagCommandHandlers;
public class TagDeleteCommandHandler : BlogDbCommandHandler<TagDeleteCommand, Tag>
{
    public TagDeleteCommandHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected override async Task<bool> GetResultToHandleAsync(TagDeleteCommand command, CancellationToken token)
    {
        await Entities.RemoveAsync(t => t.Id == command.Id && t.CreatorId == command.CreatorId, token);

        return await SaveOneEntityAsync(token);
    }
}
