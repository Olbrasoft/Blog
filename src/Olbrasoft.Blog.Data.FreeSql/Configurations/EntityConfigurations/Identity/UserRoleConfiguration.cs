using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations.Identity;
public class UserRoleConfiguration : IEntityTypeConfiguration<BlogUserToRole>
{
    public void Configure(EfCoreTableFluent<BlogUserToRole> model)
    {
        model.ToTable("Identity.UserRoles");
    }
}
