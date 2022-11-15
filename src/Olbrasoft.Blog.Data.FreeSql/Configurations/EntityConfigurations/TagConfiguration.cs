namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations;
public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EfCoreTableFluent<Tag> model)
    {
        model.ToTable("Tags");
        model.HasKey(t => t.Id);
        model.Property(t => t.Id).Help().IsIdentity(true);

        //model.Property(t => t.Created).HasDefaultValueSql("SYSDATETIMEOFFSET()");
        //model.Property(t => t.Created).Help().CanUpdate(false);

        model.HasMany(t => t.Posts).WithMany(p => p.Tags, typeof(PostToTag));
    }
}
