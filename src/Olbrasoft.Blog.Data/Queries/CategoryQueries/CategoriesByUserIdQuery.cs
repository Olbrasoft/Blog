namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoriesByUserIdQuery : ByUserIdQuery<IPagedResult<CategoryOfUserDto>>
{
    public CategoriesByUserIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public CategoriesByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}