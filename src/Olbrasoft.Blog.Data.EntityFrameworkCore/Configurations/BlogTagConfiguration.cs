using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Blog.Data.Entities;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogTagConfiguration : BlogTypeConfiguration<Tag>
    {
        public BlogTagConfiguration() : base("Tags")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasMany(p => p.ToPosts).WithOne(p => p.Tag).HasForeignKey(p => p.ToId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.Label).IsUnique();
        }
    }
}