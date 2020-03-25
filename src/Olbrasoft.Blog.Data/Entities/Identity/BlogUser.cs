using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Blog.Data.Entities.Identity
{
    public class BlogUser : IdentityUser<int>, IHaveCreated
    {
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        public DateTimeOffset Created { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new HashSet<Category>();

        public IEnumerable<Post> Posts { get; set; } = new HashSet<Post>();

        public IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();

        public IEnumerable<Tag> Tags { get; set; } = new HashSet<Tag>();

        public IEnumerable<PostToTag> PostToTags { get; set; } = new HashSet<PostToTag>();

        public IEnumerable<BlogUserToRole> ToRoles { get; set; } = new HashSet<BlogUserToRole>();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
