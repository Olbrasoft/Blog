namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoriesByExceptUserIdQuery : ExceptUserIdQuery<IPagedResult<CategoryOfUsersDto>>
{
  

    public CategoriesByExceptUserIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public CategoriesByExceptUserIdQuery(IMediator mediator) : base(mediator)
    {
       
    }
}