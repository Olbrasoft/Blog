﻿using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data.Linq.Expressions;
using Olbrasoft.Data.Paging;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsByUserIdQueryHandler : BlogDbQueryHandler<Tag, TagsByUserIdQuery, IPagedResult<TagOfUserDto>>
    {
        public TagsByUserIdQueryHandler(IProjector projector, IDbContextFactory<BlogDbContext> factory) : base(projector, factory)
        {
        }

        public override async Task<IPagedResult<TagOfUserDto>> HandleAsync(TagsByUserIdQuery query, CancellationToken token)
        {
            var filteredTags = Entities.Where(p => p.CreatorId == query.UserId);

            if (!string.IsNullOrEmpty(query.Search))
            {
                filteredTags = filteredTags.Where(p => p.Label.ToLower().Contains(query.Search.ToLower()));
            }

            var tags = ProjectTo<TagOfUserDto>(filteredTags.OrderBy(query.OrderByColumnName, query.OrderByDirection))
                 .Skip(query.Paging.CalculateSkip())
                 .Take(query.Paging.PageSize);

            return new PagedResult<TagOfUserDto>(await tags.ToArrayAsync(token))
            {
                TotalCount = await Entities.Where(p => p.CreatorId == query.UserId).CountAsync(),

                FilteredCount = await filteredTags.CountAsync()
            };
        }
    }
}