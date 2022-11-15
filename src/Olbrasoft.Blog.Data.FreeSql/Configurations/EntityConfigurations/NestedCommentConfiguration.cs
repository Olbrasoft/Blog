namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations;
public class NestedCommentConfiguration : IEntityTypeConfiguration<NestedComment>
{
    public void Configure(EfCoreTableFluent<NestedComment> model)
    {
        model.ToTable("NestedComments");
        model.Property(nc => nc.Id).Help().IsIdentity(true);
    }
}
