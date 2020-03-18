using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Data.Cqrs;
using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.CategoryQueries
{
    public class CategoryQuery : ByIdQuery<CategoryOfUserDto>
    {
        public CategoryQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}