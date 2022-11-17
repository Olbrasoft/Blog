namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers;

public class CategorySaveCommandHandler : BlogDbCommandHandler<CategorySaveCommand, Category>
{
    public CategorySaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    protected override async Task<bool> GetResultToHandleAsync(CategorySaveCommand Command, CancellationToken token)
    {
        await Entities.AddOrUpdateAsync(MapTo<Category>(Command), token);

        return await SaveOneEntityAsync(token);
    }
}