namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogPostToTagConfiguration : BlogTypeConfiguration<PostToTag>
    {
        public BlogPostToTagConfiguration() :base("PostTags")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<PostToTag> builder)
        {
            builder.HasKey(p => new { p.Id, p.ToId });
        }
    }
}