using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations.Identity;
public class BolgUserConfiguration : IEntityTypeConfiguration<BlogUser>
{
    public void Configure(EfCoreTableFluent<BlogUser> model)
    {
        model.ToTable("Identity.Users");
        model.HasMany(p => p.Tags).WithOne(p => p.Creator).HasForeignKey(p => p.CreatorId);
    }
}


