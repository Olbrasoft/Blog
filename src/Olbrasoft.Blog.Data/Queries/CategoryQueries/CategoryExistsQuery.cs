using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Blog.Data.Queries.CategoryQueries
{
    public class CategoryExistsQuery : Request<bool>
    {
        public CategoryExistsQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int? ExceptId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}