using Olbrasoft.Blog.Data.FreeSql.QueryHandlers;
using Olbrasoft.Extensions.Paging;

namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;

public class TagsByUserIdQueryHandler : BlogDbQueryHandler<Tag,TagsByUserIdQuery,IPagedResult<TagOfUserDto>>
{
    public TagsByUserIdQueryHandler(IDataSelector selector): base(selector)
    {
    }

    public async override Task<IPagedResult<TagOfUserDto>> HandleAsync(TagsByUserIdQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);

        var userTagsSelect = Select.Where(p => p.CreatorId == query.UserId);

        var direction = true;

        if (query.OrderByDirection is Olbrasoft.Data.Sorting.OrderDirection.Desc) direction = false;

        Select = userTagsSelect.OrderByPropertyName(query.OrderByColumnName, direction)
                               .IncludeMany<PostToTag>(t=>t.ToPosts);

        if (!string.IsNullOrEmpty(query.Search))
        {
            Select = Select.Where(p => p.Label.ToLower().Contains(query.Search.ToLower()));
        }

       return (await Select.Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
            .ToListAsync(s => new TagOfUserDto { PostCount = s.ToPosts.Count() }))
            .AsPagedResult((int) await userTagsSelect.CountAsync(token), (int) await Select.CountAsync(token));
           
    }
}