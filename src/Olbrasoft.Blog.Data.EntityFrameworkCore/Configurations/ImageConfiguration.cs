
namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations;
public class ImageConfiguration : BlogTypeConfiguration<Image>
{
    public ImageConfiguration() : base("Images")
    {
    }

    public override void TypeConfigure(EntityTypeBuilder<Image> builder)
    {

        builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Alt).HasMaxLength(100);
        builder.Property(p => p.Extension).HasMaxLength(10).IsRequired();
        builder.Property(p => p.MimeType).HasMaxLength(50).IsRequired();

        builder.HasIndex(i => new { i.PostId, i.Default })
            .HasFilter("[Default] = 1")
            .IsUnique();


    }
}
