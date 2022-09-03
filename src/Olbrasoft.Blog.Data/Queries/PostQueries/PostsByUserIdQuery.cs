using Olbrasoft.Blog.Data.Dtos.PostDtos;

namespace Olbrasoft.Blog.Data.Queries.PostQueries;

public class PostsByUserIdQuery : ItemsByUserIdQuery<IPagedResult<PostOfUserDto>>
{
    public PostsByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}