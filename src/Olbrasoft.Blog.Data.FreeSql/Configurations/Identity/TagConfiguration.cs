namespace Olbrasoft.Blog.Data.FreeSql.Configurations.Identity;
public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EfCoreTableFluent<Tag> model)
    {
        model.ToTable("Tags");
        model.HasMany(p => p.ToPosts).WithOne(p => p.Tag).HasForeignKey(p => p.ToId);
    }
}
