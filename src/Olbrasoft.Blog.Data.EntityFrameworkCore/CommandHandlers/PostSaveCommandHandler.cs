namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers
{
    public class PostSaveCommandHandler : BlogDbCommandHandler<PostSaveCommand,  Post>
    {
        public PostSaveCommandHandler(IMapper mapper, BlogDbContext context) : base(mapper, context)
        {
        }

        protected override async Task<bool> GetResultToHandleAsync(PostSaveCommand command, CancellationToken token)
        {
            var post = MapTo<Post>(command);
           
            if (command.TagIds.Any())
                 post.Tags = await Context.Set<Tag>().AsQueryable().Where(p => command.TagIds.Contains(p.Id)).ToArrayAsync(token);

            if (command.Id == 0)
            {
                await Entities.AddAsync(post, token);
            }
            else
            {
                var srcPost = await Entities.Include(p => p.Tags).FirstAsync(p => p.Id == command.Id, token);
               
                srcPost.Tags.Clear();
               
                await Context.SaveChangesAsync(token);
                               
                srcPost.Title = post.Title;
                srcPost.Content = post.Content;
                srcPost.CategoryId = post.CategoryId;
                srcPost.Tags = post.Tags;
                
                Entities.Update(srcPost);
            }

            return (await Context.SaveChangesAsync(token) > 1);
        }
    }
}