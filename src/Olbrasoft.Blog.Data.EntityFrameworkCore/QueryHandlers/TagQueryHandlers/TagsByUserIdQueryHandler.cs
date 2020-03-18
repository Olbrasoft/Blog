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
    public class TagsByUserIdQueryHandler : QueryHandler<Tag, TagsByUserIdQuery, IPagedResult<TagDto>>
    {
        public TagsByUserIdQueryHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<IPagedResult<TagDto>> HandleAsync(TagsByUserIdQuery query, CancellationToken cancellationToken)
        {
            var userTags = Entities.Where(p => p.CreatorId == query.UserId);

            if (!string.IsNullOrEmpty(query.Search))
            {
                userTags = userTags.Where(p => p.Label.ToLower().Contains(query.Search.ToLower()));
            }

            var tags = userTags.Select(tag => new TagDto
            {
                Id = tag.Id,
                Label = tag.Label,
                Created = tag.Created,
                PostCount = tag.ToPosts.Count()
            }).OrderBy(query.OrderByColumnName, query.OrderByDirection);

            return new PagedResult<TagDto>
            {
                Records = await tags.Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArrayAsync(),

                TotalCount = await Entities.Where(p => p.CreatorId == query.UserId).CountAsync(),

                FilteredCount = await userTags.CountAsync()
            };
        }
    }
}