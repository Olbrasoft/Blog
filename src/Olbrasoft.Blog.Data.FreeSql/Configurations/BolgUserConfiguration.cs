using FreeSql.Extensions.EfCoreFluentApi;
using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations;
public class BolgUserConfiguration : IEntityTypeConfiguration<BlogUser>
{
    public void Configure(EfCoreTableFluent<BlogUser> model)
    {
        model.ToTable("Identity.Users");
    }
}


