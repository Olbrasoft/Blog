using FreeSql.Extensions.EfCoreFluentApi;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EfCoreTableFluent<Category> model)
    {
        model.ToTable("Categories");
    }
}
