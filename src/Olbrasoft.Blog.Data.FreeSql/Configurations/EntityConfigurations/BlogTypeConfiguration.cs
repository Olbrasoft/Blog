namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations;

public abstract class BlogTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
{
    public abstract void Configure(EfCoreTableFluent<TEntity> model);
}