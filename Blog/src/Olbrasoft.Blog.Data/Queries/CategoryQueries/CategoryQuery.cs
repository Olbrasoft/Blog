namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoryQuery : ByIdQuery<CategoryOfUserDto>
{
    public CategoryQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public CategoryQuery(IMediator mediator) : base(mediator)
    {
    }
}