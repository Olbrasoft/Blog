namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogPostConfiguration : BlogTypeConfiguration<Post>
    {
        public BlogPostConfiguration() : base("","Posts")
        {
            
        }

        public override void TypeConfigure(EntityTypeBuilder<Post> builder)
        {
            builder.HasMany(p => p.Comments).WithOne(p => p.Post).HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Category).WithMany(p => p.Posts).HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.ToTags).WithOne(p => p.Post).HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}