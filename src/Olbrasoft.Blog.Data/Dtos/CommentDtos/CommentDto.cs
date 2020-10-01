using Olbrasoft.Blog.Data.Dtos.NestedCommentDtos;
using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.Dtos.CommentDtos
{
    public class CommentDto : SmallDto
    {
        public string Text { get; set; }

        public string Creator { get; set; }

        public int CreatorId { get; set; }

        public IEnumerable<NestedCommentDto> NestedComments { get; set; }
    }
}