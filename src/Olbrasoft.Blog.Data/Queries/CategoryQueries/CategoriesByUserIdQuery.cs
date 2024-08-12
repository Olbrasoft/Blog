namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoriesByUserIdQuery : ByUserIdQuery<IPagedResult<CategoryOfUserDto>>
{
    public CategoriesByUserIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public CategoriesByUserIdQuery(IMediator mediator) : base(mediator)
    {
    }
}