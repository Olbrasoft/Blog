namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations;
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EfCoreTableFluent<Post> model)
    {
        model.ToTable("Posts");

        model.HasMany(p => p.Tags).WithMany(t => t.Posts, typeof(PostToTag));

        model.Property(p => p.Id).Help().IsIdentity(true);
    }
}
