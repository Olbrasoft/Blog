using Olbrasoft.Blog.Data.Commands.TagCommands;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers
{
    public class TagSaveCommandHandler : BlogDbCommandHandler<TagSaveCommand, Tag>
    {
        public TagSaveCommandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
        {
        }

        public override async Task<bool> HandleAsync(TagSaveCommand command, CancellationToken token)
        {
            if (command.Id == 0)
            {
                await Entities.AddAsync(MapTo<Tag>(command), token);
            }
            else
            {
                var tag = await Entities.FirstAsync(p => p.Id == command.Id, token);

                tag.Label = command.Label;

                Entities.Update(tag);
            }
            
            return (await Context.SaveChangesAsync(token) == 1);
        }
    }
}