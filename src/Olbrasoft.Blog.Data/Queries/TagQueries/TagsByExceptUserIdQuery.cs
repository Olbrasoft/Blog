using Olbrasoft.Blog.Data.Dtos.TagDtos;

namespace Olbrasoft.Blog.Data.Queries.TagQueries;

public class TagsByExceptUserIdQuery : ItemsExceptUserIdQuery<IPagedResult<TagOfUsersDto>>
{
    public TagsByExceptUserIdQuery(IDispatcher dispatcher) : base(dispatcher)
    {
    }
}