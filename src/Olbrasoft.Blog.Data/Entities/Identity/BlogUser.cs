namespace Olbrasoft.Blog.Data.Entities.Identity;

public class BlogUser : Olbrasoft.Data.Entities.Identity.User
{
    public IEnumerable<Category> Categories { get; set; } = [];

    public IEnumerable<Post> Posts { get; set; } = [];

    public IEnumerable<Comment> Comments { get; set; } = [];

    public IEnumerable<NestedComment> NestedComments { get; set; } = [];

    public IEnumerable<Tag> Tags { get; set; } = [];

    public IEnumerable<BlogUserToRole> ToRoles { get; set; } = [];

    public IEnumerable<Image> Images { get; set; } = [];

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}