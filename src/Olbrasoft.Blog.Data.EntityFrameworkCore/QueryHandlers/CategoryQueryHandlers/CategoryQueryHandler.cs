using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers
{
    public class CategoryQueryHandler : QueryHandler<Category, CategoryQuery, CategoryOfUserDto>
    {
        public CategoryQueryHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<CategoryOfUserDto> HandleAsync(CategoryQuery query, CancellationToken cancellationToken)
        {
            var category = await Entities.FirstOrDefaultAsync(p => p.Id == query.Id);

            if (category != null)

                return new CategoryOfUserDto { Id = category.Id, Name = category.Name, Tooltip = category.Tooltip };

            throw new Exception("Category NotFound");
        }
    }
}