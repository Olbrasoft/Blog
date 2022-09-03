using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity
{
    public class BlogUserLoginConfiguration : BlogTypeConfiguration<UserLogin>
    {
        public BlogUserLoginConfiguration() : base("Logins")
        {
        }

        public override void TypeConfigure(EntityTypeBuilder<UserLogin> builder)

        {
            builder.HasKey(userLogin => new { userLogin.UserId, userLogin.ProviderKey });
        }
    }
}