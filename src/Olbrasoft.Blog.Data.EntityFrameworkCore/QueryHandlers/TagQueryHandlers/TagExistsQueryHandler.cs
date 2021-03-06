﻿using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.TagQueries;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.TagQueryHandlers
{
    public class TagExistsQueryHandler : BlogDbQueryHandler<Tag, TagExistsQuery>
    {
        public TagExistsQueryHandler(IDbContextFactory<BlogDbContext> factory) : base(factory)
        {
        }

        public override async Task<bool> HandleAsync(TagExistsQuery query, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(query.Label))
            {
                return await Entities.AnyAsync();
            }

            if (query.ExceptId == 0)
            {
                return await Entities.AnyAsync(p => p.Label == query.Label);
            }

            return await Entities.AnyAsync(p => p.Id != query.ExceptId && p.Label == query.Label);
        }
    }
}