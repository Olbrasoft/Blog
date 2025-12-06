using Olbrasoft.Blog.Data.Queries;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers;
public class CheckPostDefaultImageQueryHandler(BlogDbContext context) : BlogDbQueryHandler<Post, CheckPostDefaultImageQuery>(context)
{
    protected override async Task<bool> GetResultToHandleAsync(CheckPostDefaultImageQuery query, CancellationToken token)
    {
       return await Where(p=>p.Id == query.PostId).Select(p=>p.Image).FirstOrDefaultAsync(token) == query.DefaultImageFileNameAndExtension;
    }
}
