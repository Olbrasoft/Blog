using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Entities.Identity;
using Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Data.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore
{
    public class BlogDbContext : IdentityDbContext<BlogUser, BlogRole, int, UserClaim, BlogUserToRole, UserLogin, RoleClaim, UserToken>, IHaveSet
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }

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

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var property = entityType.FindProperty("Created");

                if (property != null && property.PropertyInfo.PropertyType == typeof(DateTimeOffset))
                {
                    builder.Entity(entityType.ClrType).Property(typeof(DateTimeOffset), "Created")
                       .HasDefaultValueSql("SYSDATETIMEOFFSET()");
                }
            }
            // SYSDATETIMEOFFSET()
            builder.Entity<BlogRole>().HasData(DefaultRoles);
        }
    }
}