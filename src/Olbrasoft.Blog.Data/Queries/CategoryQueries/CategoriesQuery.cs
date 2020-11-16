using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Dispatching.Common;
using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.Queries.CategoryQueries
{
    public class CategoriesQuery : Request<IEnumerable<CategorySmallDto>>
    {
        public CategoriesQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}