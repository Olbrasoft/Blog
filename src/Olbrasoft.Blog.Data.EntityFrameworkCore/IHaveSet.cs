namespace Olbrasoft.Blog.Data.EntityFrameworkCore
{
    public interface IHaveSet
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}