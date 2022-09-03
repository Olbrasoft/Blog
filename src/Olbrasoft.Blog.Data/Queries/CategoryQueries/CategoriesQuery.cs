namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoriesQuery : Request<IEnumerable<CategorySmallDto>>
{
    public CategoriesQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}