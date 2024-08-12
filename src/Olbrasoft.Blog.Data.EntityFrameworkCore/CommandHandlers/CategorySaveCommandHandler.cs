namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers;

public class CategorySaveCommandHandler : BlogDbCommandHandler<CategorySaveCommand, Category>
{
    public CategorySaveCommandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
    {
    }

    protected override async Task<bool> GetResultToHandleAsync(CategorySaveCommand Command, CancellationToken token)
    {
        if (Command.Id == 0)
        {
            //await AddAsync(MapTo<Category>(Command), token);
            await Entities.AddAsync(MapTo<Category>(Command), token);
        }
        else
        {

            var category = await GetOneOrNullAsync(p => p.Id == Command.Id, token);

            if (category is not null)
            {

                category.Name = Command.Name;

                category.Tooltip = Command.Tooltip;

                Entities.Update(category);
            }
            else throw new Exception("Category not found");
        }

        return (await Context.SaveChangesAsync(token) == 1);
    }
}