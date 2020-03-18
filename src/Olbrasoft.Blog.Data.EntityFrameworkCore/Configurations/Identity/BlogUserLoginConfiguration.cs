using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogUserLoginConfiguration : BlogTypeConfiguration<BlogUserLogin>
    {
        public BlogUserLoginConfiguration() : base("Logins")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<BlogUserLogin> builder)

        {
            builder.HasKey(userLogin => new { userLogin.UserId, userLogin.ProviderKey });
        }
    }
}