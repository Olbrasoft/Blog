namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogCategoryConfiguration : BlogTypeConfiguration<Category>
    {
        public BlogCategoryConfiguration() : base("Categories")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}