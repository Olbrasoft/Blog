namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations;

public class PostConfiguration : BlogTypeConfiguration<Post>
{
    public PostConfiguration() : base("", "Posts")
    {

    }

    public override void TypeConfigure(EntityTypeBuilder<Post> builder)
    {
        builder.HasMany(p => p.Comments).WithOne(p => p.Post).HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Images).WithOne(p => p.Post).HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Category).WithMany(p => p.Posts).HasForeignKey(p => p.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.Image).HasMaxLength(100);
    }


}