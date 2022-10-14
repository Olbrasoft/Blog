namespace Olbrasoft.Blog.Data.FreeSql.Configurations;
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EfCoreTableFluent<Post> model)
    {
        model.ToTable("Posts");
        model.HasMany(p => p.ToTags).WithOne(p => p.Post).HasForeignKey(p => p.Id);
                
    }
}
