using Olbrasoft.Data.Sorting;

namespace Olbrasoft.Blog.Data.Queries;

public abstract class PagedQuery<TResults> : BaseQuery<TResults>
{
    public int UserId { get; set; }
    public IPageInfo Paging { get; set; } = new PageInfo();
    public string Search { get; set; } = string.Empty;
    public string OrderByColumnName { get; set; } = string.Empty;
    public OrderDirection OrderByDirection { get; set; } = OrderDirection.Asc;

    public PagedQuery(IQueryProcessor processor) : base(processor)
    {
    }

    protected PagedQuery(IMediator mediator) : base(mediator)
    {
    }
}