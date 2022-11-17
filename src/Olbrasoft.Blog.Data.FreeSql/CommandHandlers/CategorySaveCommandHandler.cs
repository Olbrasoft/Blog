namespace Olbrasoft.Blog.Data.FreeSql.CommandHandlers;

public class CategorySaveCommandHandler : BlogDbCommandHandler<CategorySaveCommand, Category>
{
    public CategorySaveCommandHandler(IMapper mapper, BlogFreeSqlDbContext context) : base(mapper, context)
    {
    }

    public override async Task<bool> HandleAsync(CategorySaveCommand Command, CancellationToken token)
    {
        ThrowIfCommandIsNullOrCancellationRequested(Command, token);
        
        await Entities.AddOrUpdateAsync(MapTo<Category>(Command), token);

        return await SaveOneEntityAsync(token);
    }
}