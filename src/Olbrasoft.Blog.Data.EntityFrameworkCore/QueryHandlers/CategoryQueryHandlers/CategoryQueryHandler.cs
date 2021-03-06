﻿using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoryQueryHandler : BlogDbQueryHandler<Category, CategoryQuery, CategoryOfUserDto>
    {
        public CategoryQueryHandler(IProjector projector, IDbContextFactory<BlogDbContext> factory) : base(projector, factory)
        {
        }

        public override async Task<CategoryOfUserDto> HandleAsync(CategoryQuery query, CancellationToken token)
        {
            return await ProjectTo<CategoryOfUserDto>(Entities.Where(p => p.Id == query.Id)).FirstOrDefaultAsync(token);
        }
    }
}