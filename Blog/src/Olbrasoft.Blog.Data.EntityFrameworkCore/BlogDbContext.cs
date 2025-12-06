using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore;


/// <summary>
/// Represents the database context for the blog application.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BlogDbContext"/> class.
/// </remarks>
/// <param name="options">The options for configuring the context.</param>
public class BlogDbContext(DbContextOptions options) : IdentityDbContext<BlogUser, BlogRole, int, UserClaim, BlogUserToRole, UserLogin, RoleClaim, UserToken>(options)
{
    /// <summary>
    /// Gets or sets the categories DbSet.
    /// </summary>
    public DbSet<Category> Categories => Set<Category>();

    /// <summary>
    /// Gets or sets the posts DbSet.
    /// </summary>
    public DbSet<Post> Posts => Set<Post>();


    /// <summary>
    /// Gets or sets the comments DbSet.
    /// </summary>
    public DbSet<Comment> Comments => Set<Comment>();

    /// <summary>
    /// Gets or sets the tags DbSet.
    /// </summary>
    public DbSet<Tag> Tags => Set<Tag>();


    public DbSet<Image> Images => Set<Image>();


    /// <summary>
    /// Gets the default roles for the blog application.
    /// </summary>
    public static IEnumerable<BlogRole> DefaultRoles =>
    [
        new BlogRole { Id= 1, Name="Administrator", NormalizedName= "ADMINISTRATOR" },
        new BlogRole{ Id =2, Name="Blogger" , NormalizedName="BLOGGER" }

    ];

    /// <summary>
    /// Configures the model for the blog database.
    /// </summary>
    /// <param name="builder">The builder to use for configuring the model.</param>
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
                   .HasDefaultValueSql("SYSDATETIMEOFFSET()").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            }
        }
        // SYSDATETIMEOFFSET()
        builder.Entity<BlogRole>().HasData(DefaultRoles);
    }
}
