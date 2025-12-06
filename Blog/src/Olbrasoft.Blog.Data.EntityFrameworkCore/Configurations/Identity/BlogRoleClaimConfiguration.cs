namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations.Identity;

public class BlogRoleClaimConfiguration : BlogTypeConfiguration<RoleClaim>
{
    public BlogRoleClaimConfiguration() : base("RoleClaims")
    {
    }

    public override void TypeConfigure(EntityTypeBuilder<RoleClaim> builder)
    {
    }
}