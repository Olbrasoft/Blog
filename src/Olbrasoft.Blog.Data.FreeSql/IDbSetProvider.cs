namespace Olbrasoft.Blog.Data.FreeSql;

public interface IDbSetProvider
{
    DbSet<TEntity> Set<TEntity>() where TEntity: class;
} 