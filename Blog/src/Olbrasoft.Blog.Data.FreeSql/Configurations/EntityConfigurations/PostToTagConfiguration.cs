namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations;
public class PostToTagConfiguration : IEntityTypeConfiguration<PostToTag>
{
    public void Configure(EfCoreTableFluent<PostToTag> model)
    {
        model.ToTable("PostTags");

        model.HasOne(ptt => ptt.Post).HasForeignKey(ptt => ptt.Id);
        model.HasOne(ptt => ptt.Tag).HasForeignKey(ptt => ptt.ToId);
    }
}
