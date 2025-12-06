namespace Olbrasoft.Blog.Data.Queries.CategoryQueries;

public class CategoryExistsQuery : BaseQuery<bool>
{
    public CategoryExistsQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public CategoryExistsQuery(IMediator mediator) : base(mediator)
    {
    }

    public int? ExceptId { get; set; }
    public string Name { get; set; } = string.Empty;
}