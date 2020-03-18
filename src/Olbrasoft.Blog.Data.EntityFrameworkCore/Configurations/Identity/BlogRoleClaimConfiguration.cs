using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogRoleClaimConfiguration :BlogTypeConfiguration<BlogRoleClaim>
    {
        public BlogRoleClaimConfiguration() :base("RoleClaims")
        {
                
        }

        public override void TypeConfigure(EntityTypeBuilder<BlogRoleClaim> builder)
        {
            
        }
    }
}