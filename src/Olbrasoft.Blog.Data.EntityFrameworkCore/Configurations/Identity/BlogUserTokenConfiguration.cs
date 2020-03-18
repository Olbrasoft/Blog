using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogUserTokenConfiguration : BlogTypeConfiguration<BlogUserToken>
    {
        public BlogUserTokenConfiguration():base((string) "Tokens")
        {
            
        }
        public override void TypeConfigure(EntityTypeBuilder<BlogUserToken> builder)
        {
            builder.HasKey(userToken => new { userToken.UserId, userToken.LoginProvider, userToken.Name });
        }
    }
}