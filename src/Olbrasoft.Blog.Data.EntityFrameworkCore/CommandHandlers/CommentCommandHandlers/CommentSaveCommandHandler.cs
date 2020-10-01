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
    public class CommentSaveCommandHandler : DbCommandHandler<Comment, CommentSaveCommand>
    {
        public CommentSaveCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {
        }

        public override async Task<bool> HandleAsync(CommentSaveCommand command, CancellationToken token)
        {
            if (command.Id == 0 && command.PostId > 0)
            {
                await Set.AddAsync(MapTo<Comment>(command), token);
            }
            else
            {
                var comment = await Set.FirstOrDefaultAsync(p => p.Id == command.Id && p.CreatorId == command.CreatorId, token);

                if (comment == null)
                {
                    throw new Exception("Comment not found or you do not have permission");
                }

                comment.Text = command.Text;

                Set.Update(comment);
            }

            return await SaveAsyc(token) == 1;
        }
    }
}