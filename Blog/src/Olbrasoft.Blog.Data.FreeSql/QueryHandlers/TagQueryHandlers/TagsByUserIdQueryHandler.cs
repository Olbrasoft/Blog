namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers.TagQueryHandlers;

public class TagsByUserIdQueryHandler(BlogFreeSqlDbContext context) : BlogDbQueryHandler<Tag, TagsByUserIdQuery, IPagedResult<TagOfUserDto>>(context)
{
    protected async override Task<IPagedResult<TagOfUserDto>> GetResultToHandleAsync(TagsByUserIdQuery query, CancellationToken token)
    {
        var tagsSelect = Select;

        if (!string.IsNullOrEmpty(query.Search))
            tagsSelect = GetWhere(p => p.Label.Contains(query.Search, StringComparison.CurrentCultureIgnoreCase));

        var pagedTagsSelect = await tagsSelect.OrderByPropertyName(query.OrderByColumnName, query.OrderByDirection.ToBoolean())
                       .Page(query.Paging.NumberOfSelectedPage, query.Paging.PageSize)
                       .IncludeMany(t => t.Posts).ToListAsync(s => new TagOfUserDto { PostCount = s.Posts.Count }, token);

        return pagedTagsSelect.AsPagedResult(await tagsSelect.CountAsync(token), await GetWhere(p => p.CreatorId == query.UserId).CountAsync(token));
    }
}