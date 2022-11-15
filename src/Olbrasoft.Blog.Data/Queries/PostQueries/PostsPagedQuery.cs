namespace Olbrasoft.Blog.Data.Queries.PostQueries;

public class PostsPagedQuery : BaseQuery<IPagedEnumerable<PostDto>>
{
    public string Search { get; set; } = string.Empty;
    public IPageInfo Paging { get; set; } = new PageInfo();

    public PostsPagedQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public PostsPagedQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}
