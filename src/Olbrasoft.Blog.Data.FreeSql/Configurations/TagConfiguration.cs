using FreeSql.Extensions.EfCoreFluentApi;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations;
public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EfCoreTableFluent<Tag> model)
    {
        model.ToTable("Tags");
        model.HasMany(p => p.ToPosts).WithOne(p => p.Tag).HasForeignKey(p => p.ToId);
    }
}
