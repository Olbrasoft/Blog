using Olbrasoft.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations.Identity;
public class BlogUserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EfCoreTableFluent<UserLogin> model)
    {
        model.ToTable("Identity.Logins");
    }
}
