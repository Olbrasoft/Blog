using Olbrasoft.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations.Identity;
public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EfCoreTableFluent<RoleClaim> model)
    {
        model.ToTable("Identity.RoleClaims");
    }
}
