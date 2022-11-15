namespace Olbrasoft.Blog.Data.FreeSql;
public interface IDbContextProxy : IDbSetProvider
{
    Task<int> SaveChangesAsync(CancellationToken token);
}
