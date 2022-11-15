namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsByExceptUserIdQueryHandler : BlogDbQueryHandler<Tag, TagsByExceptUserIdQuery, IPagedResult<TagOfUsersDto>>
    {
        public TagsByExceptUserIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IPagedResult<TagOfUsersDto>> HandleAsync(TagsByExceptUserIdQuery query, CancellationToken token)
        {
            var filteredTags = EntityQueryable.Where(p => p.CreatorId != query.ExceptUserId);

            if (!string.IsNullOrEmpty(query.Search))
            {
                filteredTags = filteredTags.Where(p => p.Label.ToLower().Contains(query.Search.ToLower()));
            }

            var tags = ProjectTo<TagOfUsersDto>(filteredTags.OrderBy(query.OrderByColumnName, query.OrderByDirection))
                .Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArrayAsync(token);

            return (await tags)
                .AsPagedResult(
                await EntityQueryable.Where(p => p.CreatorId != query.ExceptUserId).CountAsync(token),
                await filteredTags.CountAsync(token));
        }
    }
}