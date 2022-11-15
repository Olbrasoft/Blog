using Olbrasoft.Data.Cqrs.FreeSql;

namespace Olbrasoft.Blog.Data.FreeSql.QueryHandlers.TagQueryHandlers;

public class TagByIdAndUserIdQueryHandler : BlogDbQueryHandler<Tag, TagByIdAndUserIdQuery, TagSmallDto>
{
    public TagByIdAndUserIdQueryHandler(IConfigure<Tag> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    public override async Task<TagSmallDto> HandleAsync(TagByIdAndUserIdQuery query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);

        return await Select.Where(p => p.CreatorId == query.UserId && p.Id == query.Id).FirstAsync<TagSmallDto>(token);
    }
}