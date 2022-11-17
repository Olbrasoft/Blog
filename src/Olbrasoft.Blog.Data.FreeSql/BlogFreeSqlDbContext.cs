using IGeekFan.AspNetCore.Identity.FreeSql;
using Olbrasoft.Blog.Data.Entities.Identity;
using Olbrasoft.Data.Entities.Identity;
using Olbrasoft.Extensions;
using System.Reflection;

namespace Olbrasoft.Blog.Data.FreeSql;

public class BlogFreeSqlDbContext : IdentityDbContext<BlogUser, BlogRole, int, UserClaim, BlogUserToRole, UserLogin, RoleClaim, UserToken>
{
    protected override void OnModelCreating(ICodeFirst builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(BlogFreeSqlDbContext).Assembly);

        var typeInfos = new[] { typeof(IEntityTypeConfiguration<>) }
        .SelectMany(openType => typeof(BlogFreeSqlDbContext).Assembly.DefinedTypes
        .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && t.AsType().ImplementsGenericInterface(openType)));

   
        foreach (TypeInfo constructibleType in typeInfos)
        {
            if (constructibleType.GetConstructor(Type.EmptyTypes) is null)
                continue;

            foreach (var @interface in constructibleType.GetInterfaces())
            {
                var entityType = @interface.GetGenericArguments().First();

                var property = entityType.GetProperty("Created");

                if (property == null || property.PropertyType != typeof(DateTimeOffset))
                    continue;

                builder.Entity(entityType, e => e.Property("Created")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                        .Help()
                        .CanUpdate(false)
                        .CanInsert(false));
            }
        }
    }

}
