using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Blog.Data.Entities;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogPostToTagConfiguration : BlogTypeConfiguration<PostToTag>
    {
        public BlogPostToTagConfiguration() :base("PostTags")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<PostToTag> builder)
        {
        }
    }
}