namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoriesByExceptUserIdQuery : ItemsExceptUserIdQuery<IPagedResult<CategoryOfUsersDto>>
{
    public CategoriesByExceptUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}