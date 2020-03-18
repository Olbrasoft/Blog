using Olbrasoft.Dispatching;

namespace Olbrasoft.Blog.Data.Queries.TagQueries
{
    public class TagExistsQuery : Request<bool>
    {
        public TagExistsQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int ExceptId { get; set; }
        public string Label { get; set; } = string.Empty;
    }
}