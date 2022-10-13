namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoriesByExceptUserIdQuery : ExceptUserIdQuery<IPagedResult<CategoryOfUsersDto>>
{
  

    public CategoriesByExceptUserIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public CategoriesByExceptUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
       
    }
}