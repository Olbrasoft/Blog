using Olbrasoft.Blog.Data.Dtos.PostDtos;
using Olbrasoft.Data.Cqrs.Requests;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.PostQueryHandlers
{
    public class PostByIdQuery : ByIdRequest<PostEditDto>
    {
        public PostByIdQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}