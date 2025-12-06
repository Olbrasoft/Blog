using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.Data.Entities;

public class Category : CreationInfo
{
    [Required]
    [StringLength(25)]
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Post> Posts { get; set; } = new HashSet<Post>();

    [StringLength(50)]
    public string? Tooltip { get; set; } = string.Empty;
}