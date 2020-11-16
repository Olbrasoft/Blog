using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Data.Cqrs.Queries;
using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.CategoryQueries
{
    public class CategoryQuery : ByIdQuery<CategoryOfUserDto>
    {
        public CategoryQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}