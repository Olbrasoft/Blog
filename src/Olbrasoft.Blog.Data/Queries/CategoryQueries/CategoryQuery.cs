namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoryQuery : ByIdRequest<CategoryOfUserDto>
{
    public CategoryQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}