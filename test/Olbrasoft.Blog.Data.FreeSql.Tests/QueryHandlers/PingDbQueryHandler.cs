using Olbrasoft.Data.Cqrs;

namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers;

internal class PingDbQueryHandler : BlogDbQueryHandler<object, BaseQuery<object>, object>
{

    public new ISelect<object> Select => base.Select; 

    public PingDbQueryHandler(IDbSetProvider setProvider) : base(setProvider)
    {
    }

    public PingDbQueryHandler(IDataSelector selector) : base(selector)
    {
    }

    public static void ThrowIf(BaseQuery<object> query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);
    }

    public override Task<object> HandleAsync(BaseQuery<object> query, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}