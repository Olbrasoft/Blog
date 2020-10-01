using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogUserConfiguration : BlogTypeConfiguration<BlogUser>
    {
        public BlogUserConfiguration() : base("Users")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<BlogUser> builder)
        {
            builder.Property(user => user.Email).HasMaxLength(256).IsRequired();

            builder.Property(user => user.UserName).HasMaxLength(256).IsRequired();

            builder.HasIndex(user => user.UserName).HasName("UserNameIndex").IsUnique();

            builder.HasMany(p => p.Posts).WithOne(p => p.Creator).HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Comments).WithOne(p => p.Creator).HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Tags).WithOne(p => p.Creator).HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PostToTags).WithOne(p => p.Creator).HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.ToRoles).WithOne(p => p.User).HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.NestedComments).WithOne(p => p.Creator).HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}