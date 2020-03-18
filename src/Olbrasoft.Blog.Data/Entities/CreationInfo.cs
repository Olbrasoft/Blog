using Olbrasoft.Blog.Data.Entities.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.Data.Entities
{
    public abstract class CreationInfo : ICreatorInfo, IHaveCreated
    {
        public int Id { get; set; }

        [Required]
        public int CreatorId { get; set; }

        [Required]
        public BlogUser Creator { get; set; }

        [DefaultValue("GetUtcDate()")]
        public DateTime Created { get; set; }
    }
}