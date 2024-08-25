namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity;

public class BlogUserClaimConfiguration : BlogTypeConfiguration<UserClaim>
{
    public BlogUserClaimConfiguration() : base((string)"UserClaims")
    {
    }

    public override void TypeConfigure(EntityTypeBuilder<UserClaim> builder)
    {
    }
}