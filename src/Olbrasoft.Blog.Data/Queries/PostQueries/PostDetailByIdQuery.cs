using Olbrasoft.Blog.Data.Dtos.PostDtos;

namespace Olbrasoft.Blog.Data.Queries.PostQueries;

public class PostDetailByIdQuery : ByIdRequest<PostDetailDto>
{
    public PostDetailByIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}