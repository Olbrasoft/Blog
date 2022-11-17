namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.TagCommandHandlers;

public class TagSaveCommandHandler : BlogDbCommandHandler<TagSaveCommand, Tag>
{
    public TagSaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    public override async Task<bool> HandleAsync(TagSaveCommand command, CancellationToken token)
    {
        ThrowIfCommandIsNullOrCancellationRequested(command, token);

        await Entities.AddOrUpdateAsync(MapTo<Tag>(command), token);

        return await SaveOneEntityAsync(token);
    }
}