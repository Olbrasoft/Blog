namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers;

public class TagSaveCommandHandler(IMapper mapper, BlogDbContext context) : BlogDbCommandHandler<TagSaveCommand, Tag>(mapper, context)
{
    protected override async Task<bool> GetResultToHandleAsync(TagSaveCommand command, CancellationToken token)
        => await SaveAsync(CreateEntity(command), token) == 1;
}