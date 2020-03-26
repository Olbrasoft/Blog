﻿using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.TagDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagsQueryHandler : DbQueryHandler<Tag, TagsQuery, IEnumerable<TagSmallDto>>
    {
        public TagsQueryHandler(IProjector projector, DbContext context) : base(projector, context)
        {
        }

        public override async Task<IEnumerable<TagSmallDto>> HandleAsync(TagsQuery query, CancellationToken token)
        {
            return await ProjectTo<TagSmallDto>(Entities.OrderBy(p => p.Label)).ToArrayAsync(token);
        }
    }
}