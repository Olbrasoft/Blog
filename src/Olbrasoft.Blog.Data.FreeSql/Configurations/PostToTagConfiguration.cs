using FreeSql.Extensions.EfCoreFluentApi;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations;
public class PostToTagConfiguration : IEntityTypeConfiguration<PostToTag>
{
    public void Configure(EfCoreTableFluent<PostToTag> model)
    {
        model.ToTable("PostTags");
        model.HasOne(p=>p.Post).WithMany(o=>o.ToTags).HasForeignKey(ptt=>ptt.Id);
    }
}
