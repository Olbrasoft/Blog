namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations;

public class TagConfiguration : BlogTypeConfiguration<Tag>
{
    public TagConfiguration() : base("Tags")
    {
    }

    public override void TypeConfigure(EntityTypeBuilder<Tag> builder) => builder.HasIndex(p => p.Label).IsUnique();
}