namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers;

public class CategorySaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : BlogDbCommandHandler<CategorySaveCommand, Category>(mapper, context)
{
    protected override async Task<bool> GetResultToHandleAsync(CategorySaveCommand command, CancellationToken token)
    {
        return await SaveAsync(CreateEntityFromCommand(command), token) == 1;
    }
}