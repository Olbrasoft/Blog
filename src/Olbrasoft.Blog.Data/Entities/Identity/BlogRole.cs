namespace Olbrasoft.Blog.Data.Entities.Identity;

public class BlogRole : Olbrasoft.Data.Entities.Identity.Role
{
    public IEnumerable<BlogUserToRole> ToUsers { get; set; } = new HashSet<BlogUserToRole>();
}