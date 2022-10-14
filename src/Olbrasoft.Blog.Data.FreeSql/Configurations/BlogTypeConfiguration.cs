namespace Olbrasoft.Blog.Data.FreeSql.Tests.Configuration;

public abstract class BlogTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
{
    public abstract void Configure(EfCoreTableFluent<TEntity> model);
}