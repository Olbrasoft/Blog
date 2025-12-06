namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EfCoreTableFluent<Category> model)
    {
        model.ToTable("Categories");

        model.Property(c => c.Id).Help().IsIdentity(true);
    }
}
