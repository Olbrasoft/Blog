using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers
{
    public class TagSaveCommandHandler : DbCommandHandler<Tag, TagSaveCommand>
    {
        public TagSaveCommandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
        {
        }

        public override async Task<bool> HandleAsync(TagSaveCommand command, CancellationToken token)
        {
            if (command.Id == 0)
            {
                await Set.AddAsync(MapTo<Tag>(command), token);
            }
            else
            {
                var tag = await Set.FirstAsync(p => p.Id == command.Id, token);

                tag.Label = command.Label;

                Set.Update(tag);
            }

            return (await SaveAsyc(token) == 1);
        }
    }
}