namespace Olbrasoft.Blog.Data.FreeSql.Configurations;
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EfCoreTableFluent<Comment> model)
    {
        model.ToTable("Comments");
    }
}
