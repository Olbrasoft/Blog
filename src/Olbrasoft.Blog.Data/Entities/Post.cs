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

    public ICollection<Comment> Comments { get; set; } = [];

    public ICollection<Tag> Tags { get; set; } = [];

    public string? Image { get; set; }

    public ICollection<Image> Images { get; set; } = [];

}