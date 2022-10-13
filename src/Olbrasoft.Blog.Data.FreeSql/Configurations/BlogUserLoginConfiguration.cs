using FreeSql.Extensions.EfCoreFluentApi;
using Olbrasoft.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations;
public class BlogUserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EfCoreTableFluent<UserLogin> model)
    {
        model.ToTable("Identity.Logins");
    }
}
