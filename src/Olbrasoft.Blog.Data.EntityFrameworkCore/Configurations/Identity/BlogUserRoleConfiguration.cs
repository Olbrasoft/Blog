using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogUserRoleConfiguration : BlogTypeConfiguration<BlogUserToRole>
    {
        public BlogUserRoleConfiguration() : base("UserRoles")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<BlogUserToRole> builder)
        {
            builder.HasKey(p => new { p.UserId, p.RoleId });
        }
    }
}