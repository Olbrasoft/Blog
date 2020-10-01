using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Blog.Data.Entities;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class NestedCommentConfiguration : BlogTypeConfiguration<NestedComment>
    {
        public NestedCommentConfiguration() : base("NestedComments")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<NestedComment> builder)
        {
        }
    }
}