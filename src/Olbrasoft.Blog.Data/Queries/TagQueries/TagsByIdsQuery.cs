using Olbrasoft.Blog.Data.Dtos.TagDtos;

namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsByIdsQuery : Request<IEnumerable<TagSmallDto>>
{
    public TagsByIdsQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public IEnumerable<int> Ids { get; set; } = Enumerable.Empty<int>();
}