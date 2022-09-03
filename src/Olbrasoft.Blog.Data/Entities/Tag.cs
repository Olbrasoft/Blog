using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.Data.Entities;

public class Tag : CreationInfo
{
    [Required]
    [StringLength(25)]
    public string Label { get; set; } = string.Empty;
    public IEnumerable<PostToTag> ToPosts { get; set; } = new HashSet<PostToTag>();
}