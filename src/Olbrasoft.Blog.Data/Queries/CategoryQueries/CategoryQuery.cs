using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Data.Cqrs.Queries;
using Olbrasoft.Data.Cqrs.Requests;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.CategoryQueries
{
    public class CategoryQuery : ByIdRequest<CategoryOfUserDto>
    {
        public CategoryQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}