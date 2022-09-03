using Olbrasoft.Blog.Data.Dtos.TagDtos;

namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsQuery : Request<IEnumerable<TagSmallDto>>
{
    public TagsQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}