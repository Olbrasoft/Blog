namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations;
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EfCoreTableFluent<Comment> model)
    {
        model.ToTable("Comments");
        model.Property(c => c.Id).Help().IsIdentity(true);
    }
}
