using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Commands.CommentCommands;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.CommentCommandHandlers
{
    public class CommentDeleteCommandHandler : DbCommandHandler<CommentDeleteCommand, BlogDbContext, Comment>
    {
        public CommentDeleteCommandHandler(IMapper mapper, IDbContextFactory<BlogDbContext> context) : base(mapper, context)
        {
        }

        public override async Task<bool> HandleAsync(CommentDeleteCommand command, CancellationToken token)
        {
            var comment = await Entities.Where(p => p.Id == command.Id && (p.CreatorId == command.CreatorId || command.CreatorId == 0)).FirstAsync(token);

            Entities.Remove(comment);

            return (await Context.SaveChangesAsync(token) == 1);
        }
    }
}