namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers.TagCommandHandlers;

public class TagSaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : BlogDbCommandHandler<TagSaveCommand, Tag>(mapper, context)
{
    protected override async Task<bool> GetResultToHandleAsync(TagSaveCommand command, CancellationToken token)
    {
        return await SaveAsync(CreateEntityFromCommand(command), token) == 1;
    }
}