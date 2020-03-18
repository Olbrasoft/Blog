using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Commands;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Data.Cqrs.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers
{
    public class PostSaveCommandHandler : CommandHandler<Post, PostSaveCommand, bool>
    {
        public PostSaveCommandHandler(BlogDbContext context) : base(context)
        {
        }

        public override async Task<bool> HandleAsync(PostSaveCommand command, CancellationToken token)
        {
            ICollection<PostToTag> toTags = new HashSet<PostToTag>();

            if (command.TagIds != null && command.UserId > 0)
            {
                var tags = await base.Context.Set<Tag>().Where(p => command.TagIds.Contains(p.Id)).ToArrayAsync(token);

                toTags = tags.Select(p => new PostToTag { ToId = p.Id, CreatorId = command.UserId }).ToArray();
            }

            if (command.Id == 0)
            {
                var post = new Post { Title = command.Title, Content = command.Content, CreatorId = command.UserId, CategoryId = command.CategoryId, ToTags = toTags };

                await Set.AddAsync(post, token);

                return (await SaveAsyc(token) > 1);
            }

            throw new NotImplementedException();
        }
    }
}