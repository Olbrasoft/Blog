
namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations;
public class ImageConfiguration : BlogTypeConfiguration<Image>
{
    public ImageConfiguration() : base("Images")
    {
    }

    public override void TypeConfigure(EntityTypeBuilder<Image> builder)
    {

        builder.Property(p => p.Path).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Alt).HasMaxLength(100);

        builder.HasIndex(i => new { i.PostId, i.Default })
            .HasFilter("[Default] = 1")
            .IsUnique();


    }
}
