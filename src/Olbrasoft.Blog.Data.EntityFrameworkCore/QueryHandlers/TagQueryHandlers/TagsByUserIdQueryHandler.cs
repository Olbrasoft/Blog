namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsByUserIdQueryHandler : BlogDbQueryHandler<Tag, TagsByUserIdQuery, IPagedResult<TagOfUserDto>>
    {
        public TagsByUserIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IPagedResult<TagOfUserDto>> HandleAsync(TagsByUserIdQuery query, CancellationToken token)
        {
            var filteredTags = EntityQueryable.Where(p => p.CreatorId == query.UserId);

            if (!string.IsNullOrEmpty(query.Search))
            {
                filteredTags = filteredTags.Where(p => p.Label.ToLower().Contains(query.Search.ToLower()));
            }

            var tags = ProjectTo<TagOfUserDto>(filteredTags.OrderBy(query.OrderByColumnName, query.OrderByDirection))
                 .Skip(query.Paging.CalculateSkip())
                 .Take(query.Paging.PageSize).ToArrayAsync(token);

            return (await tags).AsPagedResult(await EntityQueryable.Where(p => p.CreatorId == query.UserId).CountAsync(token), await filteredTags.CountAsync(token));
        }
    }
}