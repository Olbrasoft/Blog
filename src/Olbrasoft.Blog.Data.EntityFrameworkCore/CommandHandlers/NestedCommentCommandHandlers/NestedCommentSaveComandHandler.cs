using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Commands.NestedCommentCommands;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.NestedCommentCommandHandlers
{
    public class NestedCommentSaveComandHandler : DbCommandHandler<NestedCommentSaveCommand, BlogDbContext, NestedComment>
    {
        public NestedCommentSaveComandHandler(IMapper mapper, IDbContextFactory<BlogDbContext> context) : base(mapper, context)
        {
        }

        public override async Task<bool> HandleAsync(NestedCommentSaveCommand command, CancellationToken token)
        {
            if (command.Id == 0 && command.CommentId > 0)
            {
                await Entities.AddAsync(MapTo<NestedComment>(command), token);
            }
            else
            {
                var comment = await Entities.FirstOrDefaultAsync(p => p.Id == command.Id && p.CreatorId == command.CreatorId, token);

                if (comment == null)
                {
                    throw new Exception("Comment not found or you do not have permission to Edit");
                }

                comment.Text = command.Text;

                Entities.Update(comment);
            }
            return await Context.SaveChangesAsync(token) == 1;
        }
    }
}