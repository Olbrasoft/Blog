using Olbrasoft.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations.Identity;
public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EfCoreTableFluent<UserClaim> model)
    {
        model.ToTable("Identity.UserClaims");
    }
}
