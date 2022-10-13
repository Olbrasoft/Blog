using Olbrasoft.Data.Cqrs;

namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers;

internal class PingBoolDbQueryHandler : BlogDbQueryHandler<object, BaseQuery<bool>>
{
    public PingBoolDbQueryHandler(IDbSetProvider DbSetProvider) : base(DbSetProvider)
    {
    }

    public override Task<bool> HandleAsync(BaseQuery<bool> query, CancellationToken token)
    {
        throw new System.NotImplementedException();
    }
}