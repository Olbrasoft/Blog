using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.Data.Entities;

public class Comment : CreationInfo
{
    private Post? _post;

    [Required]
    [StringLength(500)]
    public string Text { get; set; } = string.Empty;

    public int PostId { get; set; }

    public Post Post
    {
        get => _post ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Post));
        set => _post = value;
    }

    public ICollection<NestedComment> NestedComments { get; set; } = new HashSet<NestedComment>();
}