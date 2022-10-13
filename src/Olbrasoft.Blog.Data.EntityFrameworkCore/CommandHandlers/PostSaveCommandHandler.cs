namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers
{
    public class PostSaveCommandHandler : BlogDbCommandHandler<PostSaveCommand,  Post>
    {
        public PostSaveCommandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
        {
        }

        public override async Task<bool> HandleAsync(PostSaveCommand command, CancellationToken token)
        {
            var post = MapTo<Post>(command);

            if (command.TagIds != null && command.TagIds.Count() > 0 && command.CreatorId > 0)
            {
                var tags = await Context.Set<Tag>().Where(p => command.TagIds.Contains(p.Id)).ToArrayAsync(token);

                var toTags = tags.Select(p => new PostToTag { ToId = p.Id, CreatorId = command.CreatorId }).ToArray();

                post.ToTags = toTags;
            }

            if (command.Id == 0)
            {
                await Entities.AddAsync(post, token);
            }
            else
            {
                var srcPost = await Entities.Include(p => p.ToTags).FirstAsync(p => p.Id == command.Id, token);

                Context.Set<PostToTag>().RemoveRange(srcPost.ToTags);

                await Context.SaveChangesAsync(token);

                srcPost.Title = post.Title;
                srcPost.Content = post.Content;
                srcPost.CategoryId = post.CategoryId;
                srcPost.ToTags = post.ToTags;

                Context.Update(srcPost);
            }

            return (await Context.SaveChangesAsync(token) > 1);
        }
    }
}