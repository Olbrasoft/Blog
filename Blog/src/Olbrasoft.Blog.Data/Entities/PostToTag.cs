namespace Olbrasoft.Blog.Data.Entities;

public class PostToTag 
{
    private Post? _post;
    private Tag? _tag;

    public int Id { get; set; }
    public int ToId { get; set; }
    public Post Post { get => _post ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Post)); set => _post = value; }
    public Tag Tag { get => _tag ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Tag)); set => _tag = value; }
}