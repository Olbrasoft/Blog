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
    public class NestedCommentDeleteCommandHandler : DbCommandHandler<NestedComment, NestedCommentDeleteCommand>
    {
        public NestedCommentDeleteCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {
        }

        public override async Task<bool> HandleAsync(NestedCommentDeleteCommand command, CancellationToken token)
        {
            var comment = await Set.Where(p => p.Id == command.Id && (p.CreatorId == command.CreatorId || command.CreatorId == 0)).FirstAsync(token);

            Set.Remove(comment);

            return (await SaveAsyc(token) == 1);
        }
    }
}