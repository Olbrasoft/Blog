namespace Olbrasoft.Blog.Data.Entities.Identity;

public class BlogUserToRole : Olbrasoft.Data.Entities.Identity.UserToRole
{
    private BlogUser? _user;
    private BlogRole? _role;

    public BlogUser User { get => _user ?? throw new InvalidOperationException(nameof(User)); set => _user = value; }
    public BlogRole Role { get => _role ?? throw new InvalidOperationException(nameof(Role)); set => _role = value; }
}