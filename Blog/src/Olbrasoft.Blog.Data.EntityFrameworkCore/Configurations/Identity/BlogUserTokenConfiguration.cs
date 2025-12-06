namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity;

public class BlogUserTokenConfiguration : BlogTypeConfiguration<UserToken>
{
    public BlogUserTokenConfiguration() : base("Tokens")
    {
    }

    public override void TypeConfigure(EntityTypeBuilder<UserToken> builder)
        => builder.HasKey(userToken => new { userToken.UserId, userToken.LoginProvider, userToken.Name });
}