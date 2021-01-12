using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Commands.CommentCommands;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using Olbrasoft.Mapping;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers.CommentCommandHandlers
{
    public class CommentSaveCommandHandler : DbCommandHandler<CommentSaveCommand, BlogDbContext, Comment>
    {
        public CommentSaveCommandHandler(IMapper mapper, IDbContextFactory<BlogDbContext> factory) : base(mapper, factory)
        {
        }

        public override async Task<bool> HandleAsync(CommentSaveCommand command, CancellationToken token)
        {
            if (command.Id == 0 && command.PostId > 0)
            {
                await Entities.AddAsync(MapTo<Comment>(command), token);
            }
            else
            {
                var comment = await Entities.FirstOrDefaultAsync(p => p.Id == command.Id && p.CreatorId == command.CreatorId, token);

                if (comment == null)
                {
                    throw new Exception("Comment not found or you do not have permission");
                }

                comment.Text = command.Text;

                Entities.Update(comment);
            }

            return await Context.SaveChangesAsync(token) == 1;
        }
    }
}