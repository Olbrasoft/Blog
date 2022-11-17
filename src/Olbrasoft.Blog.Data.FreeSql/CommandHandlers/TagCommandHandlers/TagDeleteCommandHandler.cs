namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.TagCommandHandlers;
public class TagDeleteCommandHandler : BlogDbCommandHandler<TagDeleteCommand, Tag>
{
    public TagDeleteCommandHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    public override async Task<bool> HandleAsync(TagDeleteCommand command, CancellationToken token)
    {
        ThrowIfCommandIsNullOrCancellationRequested(command, token);

        await Entities.RemoveAsync(t => t.Id == command.Id && t.CreatorId == command.CreatorId, token);

        return await SaveOneEntityAsync(token);
    }
}
