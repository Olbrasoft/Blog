using Olbrasoft.Blog.Data.Dtos.PostDtos;

namespace Olbrasoft.Blog.Data.Queries.PostQueries;

public class PostsPagedQuery : PagedQuery<IPagedEnumerable<PostDto>>
{
    public PostsPagedQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public string Search { get; set; } = string.Empty;
}