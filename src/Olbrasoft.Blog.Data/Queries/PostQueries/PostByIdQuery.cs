using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Data.Cqrs.Queries;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers
{
    public class PostByIdQuery : ByIdQuery<PostEditDto>
    {
        public PostByIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}