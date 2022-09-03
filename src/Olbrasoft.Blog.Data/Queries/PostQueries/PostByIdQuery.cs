using Olbrasoft.Blog.Data.Dtos.PostDtos;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers;

public class PostByIdQuery : ByIdRequest<PostEditDto>
{
    public PostByIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}