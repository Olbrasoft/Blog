using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers
{
    public class CategorySaveCommandHandler : DbCommandHandler<CategorySaveCommand, BlogDbContext, Category>
    {
        public CategorySaveCommandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
        {
        }

        public override async Task<bool> HandleAsync(CategorySaveCommand Command, CancellationToken token)
        {
            if (Command.Id == 0)
            {
                await Entities.AddAsync(MapTo<Category>(Command), token);
            }
            else
            {
                var category = await Entities.FirstAsync(p => p.Id == Command.Id, token);
                                
                if (category is null) 
                    throw new Exception("Category not found");
                
                category.Name = Command.Name;

                category.Tooltip = Command.Tooltip;

                Entities.Update(category);
            }

            return (await Context.SaveChangesAsync(token) == 1);
        }
    }
}