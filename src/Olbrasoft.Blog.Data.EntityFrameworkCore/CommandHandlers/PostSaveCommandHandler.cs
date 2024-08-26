namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers;

public class PostSaveCommandHandler(IMapper mapper, BlogDbContext context) : BlogDbCommandHandler<PostSaveCommand, Post, int>(mapper, context)
{
    protected override async Task<int> GetResultToHandleAsync(PostSaveCommand command, CancellationToken token)
    {
        Post post = new();

        if (command.Id > 0) //Update
        {
            post = await Entities.Include(p => p.Tags).FirstAsync(p => p.Id == command.Id, token);

            if (command.DeleteDefaultImage)
            {
                post.Image = null;
            }

            post.Tags.Clear();
        }


        MapCommandToExistingEntity(command, post);

        
        if (command.TagIds.Any())
        {
            foreach (var tag in await GetArrayAsync<Tag>(p => command.TagIds.Contains(p.Id), token))
            {
                post.Tags.Add(tag);
            }
        }

        await SaveAsync(post, token);

        return post.Id;
    }
}