namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.TagCommandHandlers;

public class TagSaveCommandHandler : BlogDbCommandHandler<TagSaveCommand, Tag>
{
    public TagSaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    protected override async Task<bool> GetResultToHandleAsync(TagSaveCommand command, CancellationToken token)
    {
        await Entities.AddOrUpdateAsync(MapTo<Tag>(command), token);

        return await SaveOneEntityAsync(token);
    }
}