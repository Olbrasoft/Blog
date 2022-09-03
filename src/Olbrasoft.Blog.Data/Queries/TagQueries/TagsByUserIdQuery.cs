using Olbrasoft.Blog.Data.Dtos.TagDtos;

namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsByUserIdQuery : ItemsByUserIdQuery<IPagedResult<TagOfUserDto>>
{
    public TagsByUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}