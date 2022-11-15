using Olbrasoft.Data.Cqrs;
using Olbrasoft.Data.Cqrs.FreeSql;

namespace Olbrasoft.Blog.Data.FreeSql.Tests.QueryHandlers;

internal class PingDbQueryHandler : BlogDbQueryHandler<object, BaseQuery<object>, object>
{
    public PingDbQueryHandler(BlogFreeSqlDbContext context) : base(context)
    {
    }

    public PingDbQueryHandler(IConfigure<object> configurator, BlogFreeSqlDbContext context) : base(configurator, context)
    {
    }

    public new ISelect<object> Select => base.Select; 



    public static void ThrowIf(BaseQuery<object> query, CancellationToken token)
    {
        ThrowIfQueryIsNullOrCancellationRequested(query, token);
    }

    public override Task<object> HandleAsync(BaseQuery<object> query, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}