namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.TagQueryHandlers;

public class TagByIdAndUserIdQueryHandler : BlogDbQueryHandler<Tag, TagByIdAndUserIdQuery, TagSmallDto>
{
    public TagByIdAndUserIdQueryHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected override async Task<TagSmallDto> GetResultToHandleAsync(TagByIdAndUserIdQuery query, CancellationToken token)
    {
        return await Select.Where(p => p.CreatorId == query.UserId && p.Id == query.Id).FirstAsync<TagSmallDto>(token);
    }
}