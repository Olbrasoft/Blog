using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers
{
    public class CategorySaveCommandHandler : CommandHandler<Category, CategorySaveCommand, bool>
    {
        public CategorySaveCommandHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<bool> HandleAsync(CategorySaveCommand Command, CancellationToken token)
        {
            if (Command.Id == null || Command.Id == 0)
            {
                await Set.AddAsync(new Category { Name = Command.Name, Tooltip = Command.Tooltip, CreatorId = Command.UserId }, token);
            }
            else
            {
                var category = await Set.FirstAsync(p => p.Id == Command.Id, token);

                if (category == null)
                {
                    throw new Exception("Category not found");
                }

                category.Name = Command.Name;

                category.Tooltip = Command.Tooltip;

                Set.Update(category);
            }

            return (await SaveAsyc(token) == 1);
        }
    }
}