using Olbrasoft.Blog.AspNetCore.Mvc.Resources;
using Olbrasoft.Blog.Data.Dtos.CommentDtos;
using Olbrasoft.Blog.Data.Dtos.PostDtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Models
{
    public class PostDetailViewModel : HomeAndPostModel
    {
        public PostDto Post { get; set; }

        public int Id { get; set; }

        public int ParentCommentId { get; set; }

        public int CommentId { get; set; }

        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof(Shared))]
        [Display(Name = "Text", Prompt = "CommentText", ResourceType = typeof(Shared))]
        public string CommentText { get; set; }

        public string CommentedCommentText { get; set; }

        public IEnumerable<CommentDto> Comments { get; set; }
    }
}