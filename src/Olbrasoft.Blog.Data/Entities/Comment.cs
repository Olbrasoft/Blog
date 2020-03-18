using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.Data.Entities
{
    public class Comment : CreationInfo
    {
        [Required] 
        public string Text { get; set; } = string.Empty;
        
        public int PostId { get; set; }

        public Post Post { get; set; }
        
    }
}