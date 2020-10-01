using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.Data.Entities
{
    public class Comment : CreationInfo
    {
        [Required]
        [StringLength(500)]
        public string Text { get; set; } = string.Empty;

        public int PostId { get; set; }

        public Post Post { get; set; }

        public ICollection<NestedComment> NestedComments { get; set; } = new HashSet<NestedComment>();
    }
}