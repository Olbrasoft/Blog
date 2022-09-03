using Olbrasoft.Blog.Data.Dtos.TagDtos;

namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsWhereLabelContainsTextQuery : Request<IEnumerable<TagSmallDto>>
{
    public TagsWhereLabelContainsTextQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }

    public IEnumerable<int> ExceptTagIds { get; set; } = Enumerable.Empty<int>();

    public string Text { get; set; } = string.Empty;
}