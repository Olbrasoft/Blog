using FreeSql.Extensions.EfCoreFluentApi;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations;
public class NestedCommentConfiguration : IEntityTypeConfiguration<NestedComment>
{
    public void Configure(EfCoreTableFluent<NestedComment> model)
    {
        model.ToTable("NestedComments");
    }
}
