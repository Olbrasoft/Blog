namespace Olbrasoft.Blog.Data.FreeSql.Tests;

public class DbSelector : IDataSelector
{
    private readonly IDbSetProvider _setProvider;

    public DbSelector(IDbSetProvider provider)
    {
        _setProvider = provider;
    }

    public ISelect<TEntity> Select<TEntity>() where TEntity : class
    {
        return _setProvider.Set<TEntity>().Select;
    }
}