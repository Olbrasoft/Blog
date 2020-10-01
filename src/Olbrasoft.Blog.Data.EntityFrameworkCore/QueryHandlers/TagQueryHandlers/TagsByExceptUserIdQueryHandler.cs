using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Data.Linq.Expressions;
using Olbrasoft.Data.Paging;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsByExceptUserIdQueryHandler : DbQueryHandler<Tag, TagsByExceptUserIdQuery, IPagedResult<TagOfUsersDto>>
    {
        public TagsByExceptUserIdQueryHandler(IProjector projector, BlogDbContext context) : base(projector, context)
        {
        }

        public override async Task<IPagedResult<TagOfUsersDto>> HandleAsync(TagsByExceptUserIdQuery query, CancellationToken token)
        {
            var filteredTags = Entities.Where(p => p.CreatorId != query.ExceptUserId);

            if (!string.IsNullOrEmpty(query.Search))
            {
                filteredTags = filteredTags.Where(p => p.Label.ToLower().Contains(query.Search.ToLower()));
            }

            var tags = ProjectTo<TagOfUsersDto>(filteredTags.OrderBy(query.OrderByColumnName, query.OrderByDirection))
                .Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize);

            return new PagedResult<TagOfUsersDto>(await tags.ToArrayAsync(token))
            {
                TotalCount = await Entities.Where(p => p.CreatorId != query.ExceptUserId).CountAsync(),

                FilteredCount = await filteredTags.CountAsync()
            };
        }
    }
}