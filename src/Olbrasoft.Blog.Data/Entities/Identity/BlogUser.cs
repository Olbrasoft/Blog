namespace Olbrasoft.Blog.Data.Entities.Identity;

public class BlogUser : Olbrasoft.Data.Entities.Identity.User
{
    public IEnumerable<Category> Categories { get; set; } = new HashSet<Category>();

    public IEnumerable<Post> Posts { get; set; } = new HashSet<Post>();

    public IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();

    public IEnumerable<NestedComment> NestedComments { get; set; } = new HashSet<NestedComment>();

    public IEnumerable<Tag> Tags { get; set; } = new HashSet<Tag>();

    public IEnumerable<PostToTag> PostToTags { get; set; } = new HashSet<PostToTag>();

    public IEnumerable<BlogUserToRole> ToRoles { get; set; } = new HashSet<BlogUserToRole>();

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}