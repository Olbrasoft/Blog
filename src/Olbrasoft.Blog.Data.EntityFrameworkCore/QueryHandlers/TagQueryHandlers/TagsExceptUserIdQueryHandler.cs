using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Data.Paging;
using Olbrasoft.Linq;
using Olbrasoft.Paging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsExceptUserIdQueryHandler : QueryHandler<Tag, TagsExceptUserIdQuery, IPagedResult<TagDto>>
    {
        public TagsExceptUserIdQueryHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<IPagedResult<TagDto>> HandleAsync(TagsExceptUserIdQuery query, CancellationToken token)
        {
            var userTags = Entities.Where(p => p.CreatorId != query.ExceptUserId);

            if (!string.IsNullOrEmpty(query.Search))
            {
                userTags = userTags.Where(p => p.Label.ToLower().Contains(query.Search.ToLower()));
            }

            var tags = userTags.Select(tag => new TagDto
            {
                Id = tag.Id,
                Label = tag.Label,
                Created = tag.Created,
                PostCount = tag.ToPosts.Count(),
                Creator = $"{tag.Creator.FirstName}  {tag.Creator.LastName}"

            }).OrderBy(query.OrderByColumnName, query.OrderByDirection);

            return new PagedResult<TagDto>()
            {
                Records = await tags.Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArrayAsync(),

                TotalCount = await Entities.Where(p => p.CreatorId != query.ExceptUserId).CountAsync(),

                FilteredCount = await userTags.CountAsync()
            };
        }
    }
}