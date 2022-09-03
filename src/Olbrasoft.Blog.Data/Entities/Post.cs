using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.Data.Entities;

public class Post : CreationInfo
{
    private Category? _category;

    [Required]
    [StringLength(33)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public Category Category { get => _category ?? throw new InvalidOperationException(nameof(Category)); set => _category = value; }

    public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    public ICollection<PostToTag> ToTags { get; set; } = new HashSet<PostToTag>();
}