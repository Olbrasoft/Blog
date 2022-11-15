namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogTagConfiguration : BlogTypeConfiguration<Tag>
    {
        public BlogTagConfiguration() : base("Tags")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<Tag> builder)
        {           
            builder.HasIndex(p => p.Label).IsUnique();
        
        }
    }
}