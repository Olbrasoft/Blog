using IGeekFan.AspNetCore.Identity.FreeSql;
using Olbrasoft.Blog.Data.Entities.Identity;
using Olbrasoft.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.FreeSql;

public class BlogFreeSqlDbContext : IdentityDbContext<BlogUser, BlogRole, int, UserClaim, BlogUserToRole, UserLogin, RoleClaim, UserToken>, IDbSetProvider
{
    protected override void OnModelCreating(ICodeFirst builder)
    {        
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(BlogFreeSqlDbContext).Assembly);
      
    }
}
