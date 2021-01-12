using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Commands.NestedCommentCommands;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.NestedCommentCommandHandlers
{
    public class NestedCommentDeleteCommandHandler : DbCommandHandler<NestedCommentDeleteCommand, BlogDbContext, NestedComment>
    {
        public NestedCommentDeleteCommandHandler(IMapper mapper, IDbContextFactory<BlogDbContext> factory) : base(mapper, factory)
        {
        }

        public override async Task<bool> HandleAsync(NestedCommentDeleteCommand command, CancellationToken token)
        {
            var comment = await Entities.Where(p => p.Id == command.Id && (p.CreatorId == command.CreatorId || command.CreatorId == 0)).FirstAsync(token);

            Entities.Remove(comment);

            return (await Context.SaveChangesAsync(token) == 1);
        }
    }
}