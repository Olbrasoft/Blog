namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoriesQuery : BaseQuery<IEnumerable<CategorySmallDto>>
{
    public CategoriesQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public CategoriesQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}