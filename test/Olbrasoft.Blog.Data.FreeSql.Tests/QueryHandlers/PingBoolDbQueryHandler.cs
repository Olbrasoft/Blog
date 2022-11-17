using Olbrasoft.Data.Cqrs;

namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers;

internal class PingBoolDbQueryHandler : BlogDbQueryHandler<object, BaseQuery<bool>>
{
    public PingBoolDbQueryHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    protected override Task<bool> GetResultToHandleAsync(BaseQuery<bool> query, CancellationToken token)
    {
        throw new System.NotImplementedException();
    }
}