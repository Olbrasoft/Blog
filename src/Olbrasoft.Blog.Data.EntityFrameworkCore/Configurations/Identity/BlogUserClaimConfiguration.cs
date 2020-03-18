using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogUserClaimConfiguration :BlogTypeConfiguration<BlogUserClaim>
    {
        public BlogUserClaimConfiguration():base((string) "UserClaims")
        {
                
        }

        public override void TypeConfigure(EntityTypeBuilder<BlogUserClaim> builder)
        {
        }
    }
}