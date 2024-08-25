namespace Olbrasoft.Blog.Data.EntityFrameworkCore.CommandHandlers;

public class PostSaveCommandHandler(IMapper mapper, BlogDbContext context) : BlogDbCommandHandler<PostSaveCommand, Post, int>(mapper, context)
{
    protected override async Task<int> GetResultToHandleAsync(PostSaveCommand command, CancellationToken token)
    {
        Post post = new();

        if (command.Id > 0)
        {
            post = await Entities.Include(p => p.Tags).FirstAsync(p => p.Id == command.Id, token);

            var defaultImage = await Context.Images.Where(i => i.PostId == command.Id && i.Default).FirstOrDefaultAsync(token);

            if (command.DefaultImage != null)
            {

                if (defaultImage != null)
                {
                    defaultImage.Path = command.DefaultImage.Path;
                    defaultImage.Alt = command.DefaultImage.Alt;
                }

            }
            else
            {
                if (defaultImage != null)
                {
                    Context.Images.Remove(defaultImage);
                }
            }

            post.Tags.Clear();
        }
        else
        {
            if (command.DefaultImage != null)
            {
                post.Images.Add(new Image
                {
                    Path = command.DefaultImage.Path,
                    Alt = command.DefaultImage.Alt,
                    Default = true
                });
            }
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