using Olbrasoft.Blog.Data.Queries;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers;
public class SpeedQueryHandler(IProjector projector, BlogDbContext context) : BlogDbQueryHandler<Tag, SpeedQuery, string>(projector, context)
{
    protected override Task<string> GetResultToHandleAsync(SpeedQuery request, CancellationToken token)
        => Task.FromResult("I am Speed query Hello world ");
}