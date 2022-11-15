using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Blog.Data.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore;

public class BlogDbContext : IdentityDbContext<BlogUser, BlogRole, int, UserClaim, BlogUserToRole, UserLogin, RoleClaim, UserToken>, IHaveSet
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Tag> Tags => Set<Tag>();

    public IEnumerable<BlogRole> DefaultRoles => new[]
    {
        new BlogRole { Id= 1, Name="Administrator", NormalizedName= "ADMINISTRATOR" },
        new BlogRole{ Id =2, Name="Blogger" , NormalizedName="BLOGGER" }
    };

    public BlogDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(BlogTypeConfiguration<>).Assembly);

        //builder.SharedTypeEntity<Dictionary<string, object>>("PostToTag", builder =>
        //{
        //    builder.Property<int>("Id");
        //    builder.Property<int>("ToId");
        //});

        builder.Entity<Post>()
            .HasMany(x => x.Tags)
            .WithMany(x => x.Posts)
            .UsingEntity<Dictionary<string, object>>("PostToTag",
                x => x.HasOne<Tag>().WithMany().HasForeignKey("ToId"),
                x => x.HasOne<Post>().WithMany().HasForeignKey("Id"),
                x => x.ToTable("PostTags").HasKey("Id", "ToId"));


        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var property = entityType.FindProperty("Created");

            if (property != null && property.PropertyInfo?.PropertyType == typeof(DateTimeOffset))
            {
                builder.Entity(entityType.ClrType).Property(typeof(DateTimeOffset), "Created")
                   .HasDefaultValueSql("SYSDATETIMEOFFSET()");
            }
        }
        // SYSDATETIMEOFFSET()
        builder.Entity<BlogRole>().HasData(DefaultRoles);
    }
}