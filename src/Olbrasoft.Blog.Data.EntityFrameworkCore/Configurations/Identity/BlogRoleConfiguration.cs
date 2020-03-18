using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogRoleConfiguration :BlogTypeConfiguration<BlogRole>
    {
        public BlogRoleConfiguration():base("Roles")
        {
                
        }

        public override void TypeConfigure(EntityTypeBuilder<BlogRole> builder)
        {
            builder.HasMany(p => p.ToUsers).WithOne(p => p.Role).HasForeignKey(p => p.RoleId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}