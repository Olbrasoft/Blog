namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers;

public class CategorySaveCommandHandler(IMapper mapper, BlogDbContext context) : BlogDbCommandHandler<CategorySaveCommand, Category>(mapper, context)
{
    protected override async Task<bool> GetResultToHandleAsync(CategorySaveCommand Command, CancellationToken token)
        => await SaveAsync(CreateEntity(Command), token) == 1;




}